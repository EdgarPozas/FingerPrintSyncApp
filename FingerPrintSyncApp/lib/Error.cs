using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FingerPrintSyncApp.Lib
{
    public enum ERRORS
    {
        INITIALIZE_SENSOR,
        CONFIG_FILE,
        CONFIG_FILE_STRUCTURE,
        CONFIG_PARSED,
        SENSOR_NOT_REGISTERED_INITIAL,
        SENSOR_NOT_REGISTERED,
        SERVER_NOT_ONLINE,
        IP_NOT_VALID,
        NOT_DEVICES,
        CLEAN_CANCELED,
        NOT_SINCRONIZED
    }
    public class Error : Exception
    {
        private static readonly Dictionary<ERRORS, string> errors = new Dictionary<ERRORS, string>()
        {
            { ERRORS.INITIALIZE_SENSOR, "Error al inicializar el sensor" },
            { ERRORS.CONFIG_FILE_STRUCTURE, "Error en la estructura del archivo de configuración" },
            { ERRORS.CONFIG_PARSED, "Error en la estructura del archivo de configuración" },
            { ERRORS.SENSOR_NOT_REGISTERED_INITIAL, "Verificación inicial fallida, revise la configuración del sensor" },
            { ERRORS.SENSOR_NOT_REGISTERED, "Sensor no registrado" },
            { ERRORS.SERVER_NOT_ONLINE, "Error al tratar de contactar con el servidor" },
            { ERRORS.CONFIG_FILE, "No se encuentra el archivo de configuración" },
            { ERRORS.IP_NOT_VALID, "Dirección IP no valida" },
            { ERRORS.NOT_DEVICES, "No hay dispositivos detectados, refresque la búsqueda en el menú \"Dispositivos\"" },
            { ERRORS.CLEAN_CANCELED, "Borrado de registros cancelado" },
            { ERRORS.NOT_SINCRONIZED, "Error al sincronizar los datos" },
        };

        private readonly ERRORS code;

        public Error(ERRORS code)
        {
            this.code = code;
        }

        public string GetMessage()
        {
            return errors[code];
        }

        public static string GetMessage(ERRORS code)
        {
            return errors[code];
        }
    }
}
