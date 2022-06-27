using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.File.Adapter
{
    /// <summary>
    /// Clase de tipo Adaptador.
    /// </summary>
    internal class LogFileAdapter
    {

        #region single
        private readonly static LogFileAdapter _instance = new LogFileAdapter();

		/// <summary>
		/// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
		/// </summary>
		public static LogFileAdapter Instance
		{
			get
			{
				return _instance;
			}
		}

		private LogFileAdapter()
		{
			
		}
		#endregion

		/// <summary>
		/// Metodo utilizado para adaptar un vector de objetos a un objeto Log.
		/// </summary>
		/// <param name="values">Vector de objetos que corresponden a la clase Log.</param>
		/// <returns>Retorna un objeto de tipo Log.</returns>
		public Log Adapt(object[] values)
		{

			
			//Parseo el mensaje segun la cantidad del split. Evita cortar el mensaje.
			string[] cosasmensaje = values[0].ToString().Split(':');			
			string mensajecompleto = cosasmensaje[1];
			if(cosasmensaje.Length > 2)
            {
				for(int i = 2; i < cosasmensaje.Length; i++)
                {
					mensajecompleto += ":" + cosasmensaje[i];
                }
            }

			//Parseo la fecha, evita cortarla a la mitad.
			string[] cosasfecha = values[1].ToString().Split(':');
			string stringfecha = cosasfecha[1];
			if (cosasfecha.Length > 2)
			{
				for (int i = 2; i < cosasfecha.Length; i++)
				{
					stringfecha += cosasfecha[i];
				}
			}


			//Parseo la severidad.
			Log.Severity severidad;
			Enum.TryParse(values[2].ToString().Split(':')[1], out severidad);


			//Parseo el stacktrace, evita cortar el texto.
			string[] cosasstacktrace = values[3].ToString().Split(':');
			string stacktracecompleto = cosasstacktrace[1];
			if (cosasstacktrace.Length > 2)
			{
				for (int i = 2; i < cosasmensaje.Length; i++)
				{
					stacktracecompleto += ":" + cosasmensaje[i];
				}
			}

			return new Log()
			{
				Fecha = stringfecha,
				Message = mensajecompleto,
				SeverityLevel = severidad,
				StackTrace = stacktracecompleto
			};




		}





	}
}
