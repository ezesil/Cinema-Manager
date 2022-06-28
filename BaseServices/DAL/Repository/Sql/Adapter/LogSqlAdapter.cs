using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;
using BaseServices.Domain;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
    /// <summary>
    /// Clase de tipo Adaptador.
    /// </summary>
    internal class LogSqlAdapter : IGenericAdapter<Log>
	{      
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




	


