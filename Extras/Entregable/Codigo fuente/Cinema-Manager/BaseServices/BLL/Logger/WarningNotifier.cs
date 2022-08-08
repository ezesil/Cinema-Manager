using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.BLL.Logger
{
    /// <summary>
    /// Modulo de notificacion en caso de bitacoras urgentes.
    /// </summary>
    internal class WarningNotifier
    {

        #region single
        private readonly static WarningNotifier _instance = new WarningNotifier();

		/// <summary>
		/// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
		/// </summary>
		public static WarningNotifier Instance
		{
			get
			{
				return _instance;
			}
		}

		private WarningNotifier()
		{
			
		}
		#endregion

		/// <summary>
		/// Escanea un mensaje en busqueda de indicios que indiquen si el evento debería ser notificado de forma urgente.
		/// </summary>
		/// <param name="L">Registro de tipo Log.</param>
		public void ScanLogMessage(Log L)
		{
			if(L.Message != null && L.Message.Contains("Critical"))
			{
				// TODO: Notificar por mail a tecnico@mail.com
			}

			else if(L.Message != null && L.Message.Contains("Fatal"))
			{
				// TODO: Notificar por mail a tecnico@mail.com y admin@mail.com
			}
		}










	}
}
