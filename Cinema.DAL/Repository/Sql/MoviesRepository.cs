using BaseServices.DAL.Repository.Sql;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cinema.DAL.Repository.Sql
{
    public class MoviesRepository : SqlRepository<Movie, MovieAdapter>, IGenericRepository<Movie>
    {
        private static string DeleteQuery
        { get => "DELETE FROM [CinemaDB].[dbo].[Peliculas] where [guid_pelicula] = @Id"; }
        private static string SelectAllQuery
        { get => "SELECT [guid_pelicula],[nombre],[idioma],[idioma_subtitulado],[activo],[duracion] FROM [CinemaDB].[dbo].[Peliculas]"; }
        private static string SelectQuery
        { get => "SELECT [guid_pelicula],[nombre],[idioma],[idioma_subtitulado],[activo],[duracion] FROM [CinemaDB].[dbo].[Peliculas] where [guid_pelicula] = @Id"; }
        private static string InsertQuery
        { get => "INSERT INTO [CinemaDB].[dbo].[Peliculas] ([nombre],[idioma],[idioma_subtitulado],[activo],[duracion]) values " +
                "(@Name, @Language, @SubtitleLanguage, @IsActive, @Duration)"; }
        private static string UpdateQuery
        { get => "UPDATE [CinemaDB].[dbo].[Peliculas] SET [nombre] = @Name, [idioma] = @Language, [idioma_subtitulado] = @SubtitleLanguage, [activo] = @IsActive, [duracion] = @Duration where [guid_pelicula] = @Id"; }

        public MoviesRepository()
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
        }

        public void Insert(Movie obj)
        {
            base.Insert(obj);
        }

        public void Update(Movie obj)
        {
            base.Update(obj);
        }

        public IEnumerable<Movie> GetAll(object paramss = null)
        {
            return base.GetAll(paramss);
        }

        public Movie GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }
    }
}
