using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL.Factory;

namespace Cinema.Business
{
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


        public List<Movie> GetAllMovies()
        {
            return _repo.GetAll().ToList();
        }

        public Movie GetMovie(Guid? id)
        {
            return _repo.GetOne(id);
        }

        public void CreateMovie(Movie movie)
        {
            _repo.Insert(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _repo.Update(movie);
        }

        public void DeleteMovie(Guid? movieid)
        {
            _repo.Delete(movieid);
        }


    }
}
