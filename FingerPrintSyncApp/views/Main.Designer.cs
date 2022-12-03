namespace FingerPrintSyncApp
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.conexiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchByIpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conexiónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SincronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendDataToServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevicesList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(421, 42);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(34, 16);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Log:";
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.BackColor = System.Drawing.SystemColors.Window;
            this.StatusText.Location = new System.Drawing.Point(424, 70);
            this.StatusText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatusText.Multiline = true;
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusText.Size = new System.Drawing.Size(547, 356);
            this.StatusText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Equipos:";
            // 
            // conexiónToolStripMenuItem
            // 
            this.conexiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchDevicesToolStripMenuItem,
            this.SearchByIpToolStripMenuItem});
            this.conexiónToolStripMenuItem.Name = "conexiónToolStripMenuItem";
            this.conexiónToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.conexiónToolStripMenuItem.Text = "Dispositivos";
            // 
            // SearchDevicesToolStripMenuItem
            // 
            this.SearchDevicesToolStripMenuItem.Name = "SearchDevicesToolStripMenuItem";
            this.SearchDevicesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.SearchDevicesToolStripMenuItem.Text = "Buscar en la red";
            this.SearchDevicesToolStripMenuItem.Click += new System.EventHandler(this.SearchDevicesToolStripMenuItem_Click);
            // 
            // SearchByIpToolStripMenuItem
            // 
            this.SearchByIpToolStripMenuItem.Name = "SearchByIpToolStripMenuItem";
            this.SearchByIpToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.SearchByIpToolStripMenuItem.Text = "Buscar por IP";
            this.SearchByIpToolStripMenuItem.Click += new System.EventHandler(this.SearchByIpToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexiónToolStripMenuItem1,
            this.conexiónToolStripMenuItem,
            this.baseDeDatosToolStripMenuItem,
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(988, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conexiónToolStripMenuItem1
            // 
            this.conexiónToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToolStripMenuItem,
            this.DisconnectToolStripMenuItem});
            this.conexiónToolStripMenuItem1.Name = "conexiónToolStripMenuItem1";
            this.conexiónToolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.conexiónToolStripMenuItem1.Text = "Conexión";
            // 
            // ConnectToolStripMenuItem
            // 
            this.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            this.ConnectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ConnectToolStripMenuItem.Text = "Conectar";
            this.ConnectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // DisconnectToolStripMenuItem
            // 
            this.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            this.DisconnectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.DisconnectToolStripMenuItem.Text = "Desconectar";
            this.DisconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItem_Click);
            // 
            // baseDeDatosToolStripMenuItem
            // 
            this.baseDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SincronizeToolStripMenuItem,
            this.SendDataToServerToolStripMenuItem,
            this.CleanRegistersToolStripMenuItem});
            this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
            this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.baseDeDatosToolStripMenuItem.Text = "Base de datos";
            // 
            // SincronizeToolStripMenuItem
            // 
            this.SincronizeToolStripMenuItem.Name = "SincronizeToolStripMenuItem";
            this.SincronizeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.SincronizeToolStripMenuItem.Text = "Sincronizar con servidor";
            this.SincronizeToolStripMenuItem.Click += new System.EventHandler(this.SincronizeToolStripMenuItem_Click);
            // 
            // SendDataToServerToolStripMenuItem
            // 
            this.SendDataToServerToolStripMenuItem.Name = "SendDataToServerToolStripMenuItem";
            this.SendDataToServerToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.SendDataToServerToolStripMenuItem.Text = "Enviar datos al servidor";
            this.SendDataToServerToolStripMenuItem.Click += new System.EventHandler(this.SendDataToServerToolStripMenuItem_Click);
            // 
            // CleanRegistersToolStripMenuItem
            // 
            this.CleanRegistersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteUsersToolStripMenuItem,
            this.DeleteLogsToolStripMenuItem});
            this.CleanRegistersToolStripMenuItem.Name = "CleanRegistersToolStripMenuItem";
            this.CleanRegistersToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.CleanRegistersToolStripMenuItem.Text = "Limpiar registros";
            // 
            // DeleteUsersToolStripMenuItem
            // 
            this.DeleteUsersToolStripMenuItem.Name = "DeleteUsersToolStripMenuItem";
            this.DeleteUsersToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.DeleteUsersToolStripMenuItem.Text = "Usuarios";
            this.DeleteUsersToolStripMenuItem.Click += new System.EventHandler(this.DeleteUsersToolStripMenuItem_Click);
            // 
            // DeleteLogsToolStripMenuItem
            // 
            this.DeleteLogsToolStripMenuItem.Name = "DeleteLogsToolStripMenuItem";
            this.DeleteLogsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.DeleteLogsToolStripMenuItem.Text = "Logs";
            this.DeleteLogsToolStripMenuItem.Click += new System.EventHandler(this.DeleteLogsToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadFileToolStripMenuItem,
            this.CreateFileToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // LoadFileToolStripMenuItem
            // 
            this.LoadFileToolStripMenuItem.Name = "LoadFileToolStripMenuItem";
            this.LoadFileToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.LoadFileToolStripMenuItem.Text = "Cargar archivo";
            this.LoadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // CreateFileToolStripMenuItem
            // 
            this.CreateFileToolStripMenuItem.Name = "CreateFileToolStripMenuItem";
            this.CreateFileToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.CreateFileToolStripMenuItem.Text = "Crear archivo";
            this.CreateFileToolStripMenuItem.Click += new System.EventHandler(this.CreateFileToolStripMenuItem_Click);
            // 
            // DevicesList
            // 
            this.DevicesList.FormattingEnabled = true;
            this.DevicesList.ItemHeight = 16;
            this.DevicesList.Location = new System.Drawing.Point(16, 70);
            this.DevicesList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DevicesList.Name = "DevicesList";
            this.DevicesList.Size = new System.Drawing.Size(400, 356);
            this.DevicesList.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(888, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Versión: 1.3";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 443);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DevicesList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente lector de huellas";
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem conexiónToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SearchDevicesToolStripMenuItem;
        private System.Windows.Forms.ListBox DevicesList;
        private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SincronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexiónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchByIpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendDataToServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CleanRegistersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteLogsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}