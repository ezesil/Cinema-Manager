using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain.Logs;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Clase de tipo Adaptador.
    /// </summary>
    internal class LogSqlAdapter
	{
        #region single
        private readonly static LogSqlAdapter _instance = new LogSqlAdapter();

		/// <summary>
		/// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
		/// </summary>
		public static LogSqlAdapter Instance
		{
			get
			{
				return _instance;
			}
		}

		private LogSqlAdapter()
		{

		}
		#endregion

		/// <summary>
		/// Adapta el vector de objetos correspondiente a un objeto de bitacora.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>Retorna un objeto de tipo Log.</returns>
		public Log Adapt(object[] item)
		{
			Log L = new Log();
			L.Fecha = "[" + item[0].ToString() + "]";
			L.Message = item[1].ToString();
			Enum.TryParse(item[2].ToString(), out L.SeverityLevel);
			L.StackTrace = item[3].ToString();

			return L;

		}
	}

}




	


