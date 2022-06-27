using Cinema.DAL.Interfaces;
using Cinema.Domain;
using System;


namespace Cinema.DAL.Repository.Sql.Adapter
{
    public class MovieAdapter : IGenericAdapter<Movie>
    {
        public Movie Adapt(object[] values)
        {
            return new Movie()
            {
                Id = Guid.Parse(values[0].ToString()),
                Name = values[1].ToString(),
                Language = values[2].ToString(),
                SubtitleLanguage = values[3].ToString(),
                IsActive = bool.Parse(values[4].ToString()),
                Duration = int.Parse(values[5].ToString())
            };
        }
    }
}
