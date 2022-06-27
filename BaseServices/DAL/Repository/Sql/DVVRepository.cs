using BaseServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServices.DAL.Repository.Sql 
{
    /// <summary>
    /// Repositorio de digito verificador vertical.
    /// </summary>
    internal class DVVRepository : IGenericDVVRepository
    {
        #region Statements

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[DigitoVerificadorVertical] SET DVV = @DVV WHERE Entity_ID = @Entity_ID";
        }


        private string SelectOneStatement
        {
            get => "SELECT DVV FROM [dbo].[DigitoVerificadorVertical] WHERE Entity_ID = @id";
        }
        #endregion



        /// <summary>
        /// Permite actualizar el DVV.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dvv"></param>
        public void Update(int id, int dvv)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Obtiene el DVV de una entidad a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
