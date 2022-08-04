using BaseServices.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.File.Adapter
{
	/// <summary>
	/// Clase de tipo Adaptador. Las clases de tipo Legacy están en estado obsoleto.
	/// </summary>
	internal class LegacyLogFileAdapter
	{

		#region single
		private readonly static LegacyLogFileAdapter _instance = new LegacyLogFileAdapter();

		/// <summary>
		/// Propiedad estatica que permite accesar los atributos, propiedades y metodos publicos de una clase con patrón Singleton.
		/// </summary>
		public static LegacyLogFileAdapter Instance
		{
			get
			{
				return _instance;
			}
		}

		private LegacyLogFileAdapter()
		{

		}
		#endregion

		/// <summary>
		/// Metodo utilizado para adaptar un vector de objetos correspondientes a una bitacora a un objeto string.
		/// </summary>
		/// <param name="item">Vector de objetos que corresponden a la clase string, representando los contenidos de la bitacora.</param>
		/// <returns>Retorna un objeto de tipo string.</returns>
		public string Adapt(object[] item)
		{
			return item[0].ToString();
		}






	}
}