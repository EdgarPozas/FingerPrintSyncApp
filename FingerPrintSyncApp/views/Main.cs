using System;
using System.Windows.Forms;
using FingerPrintSyncApp.Lib;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FingerPrintSyncApp
{
	partial class Main : Form
	{
		private readonly List<ZKTecoDevice> Devices;
		private readonly API Api;

		public Main()
		{
			InitializeComponent();
			Devices = new List<ZKTecoDevice>();
			Api = new API();
		}

		#region Form Events

		private async void CaptureForm_Load(object sender, EventArgs e)
		{
			try
			{
				ChangeTitle("Desconectado");
				MakeReport("Inicializando configuración");
				Config config = Config.GetInstance();
				bool exists = config.ExistsFile();
				if (!exists)
					throw new Error(ERRORS.CONFIG_FILE);
				config.ParseFile();
				MakeReport("Archivo de configuración cargado correctamente");
				ChangeTitle("Intentando conectar");
				MakeReport("Intentando conectar con el servidor");
				bool isOnline = await Api.isOnline();
				if(!isOnline)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);
				ChangeTitle("Conectado");
				MakeReport("Conexión exítosa");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
			catch
			{
				MakeReport(Error.GetMessage(ERRORS.SERVER_NOT_ONLINE));
			}
		}

		private async void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				await Api.isOnline();
				MakeReport("Desconectado");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private async void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Config config = Config.GetInstance();
				bool exists = config.ExistsFile();
				MakeReport("Inicializando configuración");
				if (!exists)
					throw new Error(ERRORS.CONFIG_FILE);
				config.ParseFile();
				MakeReport("Archivo de configuración cargado correctamente");
				ChangeTitle("Intentando conectar");
				MakeReport("Intentando conectar con el servidor");
				bool isConected = await Api.isOnline();
				if (!isConected)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);
				ChangeTitle("Conectado");
				MakeReport("Conexión exítosa");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
			catch
			{
				ChangeTitle("Desconectado");
				MakeReport(Error.GetMessage(ERRORS.SERVER_NOT_ONLINE));
			}
		}

		private async void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ChangeTitle("Desconectando");
				MakeReport("Intentando desconectar con el servidor");
				bool isDisconnected = await Api.isOnline();
				if (!isDisconnected)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);
				ChangeTitle("Desconectado");
				MakeReport("Desconectado");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
			catch
			{
				ChangeTitle("Desconectado");
				MakeReport(Error.GetMessage(ERRORS.SERVER_NOT_ONLINE));
			}
		}

		private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Config config = Config.GetInstance();
				bool exists = config.ExistsFile();
				MakeReport("Inicializando configuración");
				if (!exists)
					throw new Error(ERRORS.CONFIG_FILE);
				config.ParseFile();
				MakeReport("Archivo de configuración cargado correctamente");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private void CreateFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Config config = Config.GetInstance();
				config.CreateFile();
				MakeReport("Creando archivo de configuración por default");
				config.ParseFile();
				MakeReport("Archivo de configuración cargado correctamente");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private async void SearchDevicesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Config config = Config.GetInstance();
				config.ParseFile();
				string network = config.Content["network_base"];
				int hosts = int.Parse(config.Content["hosts"]);
				await UpdateDevicesList(network, hosts);
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private async void SearchByIpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string network = Interaction.InputBox("Ingrese la IP", "Buscar por Ip", "192.168.3.22", 100, 100);
				await UpdateDevicesList(network);
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private async void SincronizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
            try
            {
				MakeReport($"Iniciando sincronización con los equipos ZKTeco");
				if(Devices.Count == 0)
					throw new Error(ERRORS.NOT_DEVICES);

				bool isOnline = Storage.GetInstance().isOnline;
				if (!isOnline)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);

				await SendCurrentData();

				MakeReport($"Descargando empleados");
				var employeeResponse = await Api.DownloadEmployees();
				if (employeeResponse == null)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);
				var employees = employeeResponse.data;

				MakeReport($"{employees.Count} empleados descargados");

				MakeReport($"Descargando configuración");
				var configResponse = await Api.DownloadConfig();
				if (configResponse == null)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);
				var config = configResponse.data;

				MakeReport($"Configuración descargada");
				MakeReport($"Hora en servidor: {config.time}");
				MakeReport($"Zona horaria: {config.time_zone}");
				MakeReport($"{config.sensors.Count} sensores");

				foreach (var sensor in config.sensors)
                {	
					MakeReport($"Tratando de configurar equipo {sensor.serial_number}");
					var device = Devices.Find(x => x.SerialNumber == sensor.serial_number);
					if (device == null)
                    {
						MakeReport($"Equipo {sensor.serial_number} no encontrado");
						continue;
                    }

					var serverDateTime = DateTime.Parse(config.time);
					device.SetDeviceTime(serverDateTime);
					MakeReport($"Hora actualizada en {sensor.serial_number} a {serverDateTime}");

					MakeReport($"Actualizando usuarios en {sensor.serial_number}");
					device.DeleteUsers();

					MakeReport($"Actualizando usuario administrador en {sensor.serial_number}");

					var admin = new ZKTecoUser()
					{
						EnrollNumber = "1",
						Name = "Soporte",
						Password = sensor.admin_password,
						Privelage = 2,
						Enabled = true
					};

					device.CreateUser(admin);

                    foreach (var employee in employees)
                    {
						var fingers = new List<ZKTecoFinger>();
						employee.finger_prints.ForEach(x => fingers.Add(new ZKTecoFinger() { FingerIndex = x.finger_index, Template = x.template, Flag = 1, TemplateLength = x.template.Length }));
						var user = new ZKTecoUser()
						{
							EnrollNumber = employee.employee_number.ToString(),
							Name = employee.name,
							Password = employee.pin_code,
							CardCode = employee.card_code,
							Privelage = 0,
							Enabled = true,
							Fingers = fingers
						};
						device.CreateUser(user);
						device.UpdateTemplates(user);
						MakeReport($"Usuario {employee.employee_number} - {employee.name} creado en {sensor.serial_number}");
					}
                }
				MakeReport($"Sincronización de los ZKTeco terminada exitosamente");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private async void SendDataToServerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				await SendCurrentData();
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private void DeleteUsersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				bool isOnline = Storage.GetInstance().isOnline;
				if (!isOnline)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);

				MakeReport($"Intentando borrar los usuarios en equipos ZKTeco");
				var result = MessageBox.Show("¿Estás seguro de borrar los usuarios en los equipos?", "Confirmación", MessageBoxButtons.YesNo);
				if (result == DialogResult.No)
					throw new Error(ERRORS.CLEAN_CANCELED);
				foreach (var device in Devices)
				{
					bool isDeleted = device.DeleteUsers();
					if (!isDeleted)
					{
						MakeReport($"No se pudo borrar los usuarios en el equipo {device.SerialNumber}");
						continue;
					}
					MakeReport($"Usuarios borradosen {device.SerialNumber}");
				}
				MakeReport($"Borrado de usuarios terminado");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private void DeleteLogsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				bool isOnline = Storage.GetInstance().isOnline;
				if (!isOnline)
					throw new Error(ERRORS.SERVER_NOT_ONLINE);

				MakeReport($"Intentando borrar registros en equipos ZKTeco");
				var result = MessageBox.Show("¿Estás seguro de borrar los registros en los equipos?", "Confirmación", MessageBoxButtons.YesNo);
				if (result == DialogResult.No)
					throw new Error(ERRORS.CLEAN_CANCELED);
				foreach (var device in Devices)
				{
					bool isDeleted = device.DeleteLogs();
					if (!isDeleted)
					{
						MakeReport($"No se pudo borrar los registos en el equipo {device.SerialNumber}");
						continue;
					}
					MakeReport($"Registros borrados en {device.SerialNumber}");
				}
				MakeReport($"Borrado de registros terminado");
			}
			catch (Error ex)
			{
				MakeReport(ex.GetMessage());
			}
		}

		private async Task SendCurrentData()
        {
			MakeReport($"Intentando enviar datos al servidor");
			if (Devices.Count == 0)
				throw new Error(ERRORS.NOT_DEVICES);

			MakeReport($"Enviando información de empleados");
			foreach (var device in Devices)
			{
				var allUsers = new List<ZKTecoUserRequest>();
				var allLogs = new List<ZKTecoLogRequest>();
				var WarehouseId = Config.GetInstance().Content["warehouse_id"];

				MakeReport($"Obteniendo usuarios de {device.SerialNumber}");
				var users = device.GetAllUsers();
				users.ForEach((user) =>
				{
					var user_ = new ZKTecoUserRequest(user)
					{
						SerialNumber = device.SerialNumber
					};
					allUsers.Add(user_);
				});

				MakeReport($"Obteniendo registros de {device.SerialNumber}");
				var logs = device.GetAllLogs();
				logs.ForEach((log) =>
				{
					var log_ = new ZKTecoLogRequest(log)
					{
						SerialNumber = device.SerialNumber
					};
					allLogs.Add(log_);
				});

				MakeReport($"Enviando datos de {device.SerialNumber} al servidor, puede tomar unos minutos");
				bool isSent = await Api.SendRequestSynchronize(device.SerialNumber, allUsers, allLogs);
				if (!isSent)
					throw new Error(ERRORS.NOT_SINCRONIZED);
				MakeReport($"Datos enviados correctamente");
			}

			MakeReport($"Envío de datos finalizado");
		}

		#endregion

		#region Update UI

		public async Task UpdateDevicesList(string network, int hosts = 1)
        {
			Config config = Config.GetInstance();
			config.ParseFile();
			int timeout = int.Parse(config.Content["timeout"]);
			float posibleTime = timeout * 5 * hosts / 1000;
			MakeReport($"Iniciando escaneo en la red {network} con {hosts} hosts, tiempo aproximado {posibleTime} segundos");
			
			var addresses = await Utils.ScanNetwork(network, hosts, timeout);
			MakeReport($"Intentando conectar con los equipos ZKTeco");

			DevicesList.Items.Clear();

            for (int i = 0; i < addresses.Count; i++)
            {
				var address = addresses[i];
				var device = new ZKTecoDevice();
				bool isConnected = await device.Connect(address.ToString(), 4370, i + 1);
				if (isConnected)
				{
					DevicesList.Items.Add($"{address} - {await device.GetDeviceInfo()}");
					Devices.Add(device);
				}
			}

			MakeReport($"Escaneo finalizado");
		}

		public void MakeReport(string message)
		{
			string msg = message + "\r\n";
			StatusText.AppendText(msg);
			Log.GetInstance().WriteFile(msg);
		}

		public void ChangeTitle(string title)
		{
			Text = "Cliente lector de huellas - " + title;
		}

        #endregion

    }
}