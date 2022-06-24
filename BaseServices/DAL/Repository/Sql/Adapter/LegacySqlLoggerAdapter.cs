using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseServices.DAL.Interfaces;

namespace BaseServices.DAL.Repository.Sql.Adapter
{
	/// <summary>
	/// Clase de tipo Adaptador. Las clases con titulo "Legacy" estan obsoletas y serán removidas en versiones futuras. Use la "no-legacy" en su lugar.
	/// </summary>
	internal class LegacySqlLoggerAdapter
	{
		/// <summary>
		/// Metodo utilizado para adaptar un vector de objetos correspondiente a un objeto de bitacora.
		/// </summary>
		/// <param name="item">Vector de objetos que corresponden a la clase Bitacora proveniente de SQL.</param>
		/// <returns>Retorna un objeto de tipo string.</returns>
		public string Adapt(object[] item)
		{
			return item[0].ToString();
		}
	}

}




	


