using BaseServices.DAL.Repository.Sql;
using BaseServices.Services;
using Cinema.DAL.Interfaces;
using Cinema.DAL.Repository.Sql.Adapter;
using Cinema.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cinema.DAL.Repository.Sql
{
    /// <summary>
    /// Repositorio de peliculas.
    /// </summary>
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

        ExceptionHandler? _exhandler { get; set; }
        Logger? _logger { get; set; }

        /// <summary>
        /// Constructor sin parametros.
        /// </summary>
        public MoviesRepository()
            : base(DeleteQuery, SelectAllQuery, SelectQuery, InsertQuery, UpdateQuery)
        {
            _exhandler = ServiceContainer.Instance.GetService<ExceptionHandler>();
            _logger = ServiceContainer.Instance.GetService<Logger>();
        }

        /// <summary>
        /// Inserta una pelicula.
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(Movie obj)
        {
            base.Insert(obj);
        }

        /// <summary>
        /// Actualiza una pelicula.
        /// </summary>
        /// <param name="obj"></param>
        public void Update(Movie obj)
        {
            base.Update(obj);
        }

        /// <summary>
        /// Obtiene todas las peliculas.
        /// </summary>
        /// <param name="paramss"></param>
        /// <returns></returns>
        public IEnumerable<Movie> GetAll(object paramss = null)
        {
            return base.GetAll(paramss);
        }

        /// <summary>
        /// Obtiene una pelicula.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Movie GetOne(Guid? guid)
        {
            return base.GetOne(new { Id = guid });
        }

        /// <summary>
        /// Borra una pelicula.
        /// </summary>
        /// <param name="guid"></param>
        public void Delete(Guid? guid)
        {
            base.Delete(new { Id = guid });
        }
    }
}
