using BaseServices.Services;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql
{
    /// <summary>
    /// Repositorio de salas.
    /// </summary>
    public class RoomsRepository : SqlRepository<Room, RoomAdapter>, IGenericRepository<Room>
    {
        private static string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Salas] where guid_sala = @Id"; }
        private static string SelectAllQuery
        { get => "SELECT [guid_sala],[codigo_identificador],[es_pantalla_gigante],[es_3D],[activo] FROM [CinemaDB].[dbo].[Salas]"; }
        private static string SelectQuery
        { get => "SELECT [guid_sala],[codigo_identificador],[es_pantalla_gigante],[es_3D],[activo] FROM [CinemaDB].[dbo].[Salas] where [guid_sala] = @Id"; }
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Salas] ([guid_sala], [codigo_identificador],[es_pantalla_gigante],[es_3D],[activo]) values (@Id, @Identifier, @HasBigScreen, @Has3D, @IsActive)"; }
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Salas] SET [codigo_identificador] = @Identifier,[es_pantalla_gigante] = @HasBigScreen,[es_3D] = @Has3D,[activo] = @IsActive where [guid_sala] = @Id"; }
        
        ExceptionHandler? _exhandler { get; set; }
        Logger? _logger { get; set; }

        /// <summary>
        /// Constructor por defecto sin párametros.
        /// </summary>
        public RoomsRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
            _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
            _logger = ServiceContainer.Instance.GetService<Logger>();
        }

        /// <summary>
        /// Borra una sala.
        /// </summary>
        /// <param name="guid"></param>
        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }

        /// <summary>
        /// Obtiene todas las salas
        /// </summary>
        /// <param name="paramss"></param>
        /// <returns></returns>
        public IEnumerable<Room> GetAll(object paramss = null)
        {
            return base.GetAll(paramss);
        }

        /// <summary>
        /// Obtiene una sala.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Room GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        /// <summary>
        /// Inserta una sala.
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(Room obj)
        {
            obj.Id = Guid.NewGuid();
            base.Insert(obj);
        }

        /// <summary>
        /// Actualiza una sala.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Room obj)
        {
            base.Update(obj);
        }
    }
}
