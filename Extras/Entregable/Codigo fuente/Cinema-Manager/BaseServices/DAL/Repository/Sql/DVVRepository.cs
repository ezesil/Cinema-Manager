using BaseServices.DAL.Interfaces;
using BaseServices.DAL.Repository.Sql.Adapter;
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
    internal class DVVRepository : SqlRepository<Object, GenericObjAdapter<object>>, IGenericDVVRepository
    {

        private static string DeleteQuery
        { get => ""; }
        private static string SelectAllQuery
        { get => ""; }
        private static string InsertQuery
        { get => ""; }
        private static string SelectQuery
        { get => "SELECT DVV FROM [dbo].[DigitoVerificadorVertical] WHERE Entity_ID = @id"; }
        private static string UpdateQuery
        { get => "UPDATE [dbo].[DigitoVerificadorVertical] SET DVV = @dvv WHERE Entity_ID = @id"; }

        public DVVRepository()
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        /// <summary>
        /// Permite actualizar el DVV.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dvv"></param>
        public void Update(int id, int dvv)
        {
            base.Update(new {id, dvv});

        }

        /// <summary>
        /// Obtiene el DVV de una entidad a partir de su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectOne(int id)
        {
            return (int)base.GetOne(new { id });
        }
    }
}
