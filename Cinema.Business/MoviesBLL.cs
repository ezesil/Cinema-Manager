using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.Factory;

namespace Cinema.Business
{
    /// <summary>
    /// Clase singleton con para la logica de Ajnr'
    /// </summary>
    public class MoviesBLL
    {
        private readonly IGenericRepository<Movie> _repo = FactoryDAL.MovieRepository;

        #region Singleton
        private static MoviesBLL _instance = new MoviesBLL();

        /// <summary>
        /// Instancia actual de la clase.
        /// </summary>
        public static MoviesBLL Current
        {
            get
            {
                if(_instance == null)
                    _instance = new MoviesBLL();

                return _instance;
            }
        }

        private MoviesBLL()
        {

        }
        #endregion

        /// <summary>
        /// Obtriene todas las peliculas.
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            return _repo.GetAll().ToList();
        }

        /// <summary>
        /// Obtiene una pelicula.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Movie GetMovie(Guid? id)
        {
            return _repo.GetOne(id);
        }

        /// <summary>
        /// Crea una pelicula.
        /// </summary>
        /// <param name="movie"></param>
        public void CreateMovie(Movie movie)
        {
            _repo.Insert(movie);
        }

        /// <summary>
        /// Actualiza una pelicula.
        /// </summary>
        /// <param name="movie"></param>
        public void UpdateMovie(Movie movie)
        {
            _repo.Update(movie);
        }
        /// <summary>
        /// Borra una pelicula.
        /// </summary>
        /// <param name="movieid"></param>
        public void DeleteMovie(Guid? movieid)
        {
            _repo.Delete(movieid);
        }


    }
}
