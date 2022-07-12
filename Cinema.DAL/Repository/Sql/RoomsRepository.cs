﻿using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository.Sql
{
    public class RoomsRepository : SqlRepository<Room, RoomAdapter>, IGenericRepository<Room>
    {
        private static string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Salas] where guid_sala = @Id"; }
        private static string SelectAllQuery
        { get => "SELECT [guid_sala],[codigo_identificador],[es_pantalla_gigante],[es_3D],[activo] FROM [CinemaDB].[dbo].[Salas]"; }
        private static string SelectQuery
        { get => "SELECT [guid_sala],[codigo_identificador],[es_pantalla_gigante],[es_3D],[activo] FROM [CinemaDB].[dbo].[Salas] where [guid_sala] = @Id"; }
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Salas] ([codigo_identificador],[es_pantalla_gigante],[es_3D],[activo]) values (@Identifier, @HasBigPicture, @Has3D, @IsActive)"; }
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Salas] SET [codigo_identificador] = @Identifier,[es_pantalla_gigante] = @HasBigPicture,[es_3D] = @Has3D,[activo] = @IsActive where [guid_pelicula] = @Id"; }


        public RoomsRepository() : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }


        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }

        public IEnumerable<Room> GetAll()
        {
            return base.GetAll();
        }

        public Room GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        public void Insert(Room obj)
        {
            base.Insert(obj);
        }

        public void Update(Room obj)
        {
            base.Update(obj);
        }
    }
}