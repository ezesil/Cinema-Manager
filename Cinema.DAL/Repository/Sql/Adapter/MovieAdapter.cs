using Cinema.DAL.Interfaces;
using Cinema.Domain;
using Cinema.Domain.Extensions;
using System;


namespace Cinema.DAL.Repository.Sql.Adapter
{
    public class MovieAdapter : IGenericAdapter<Movie>
    {
        public Movie Adapt(object[] values)
        {
            return new Movie()
            {
                Id = values[0].ToGuid(),
                Name = values[1].ToString(),
                Language = values[2].ToString(),
                SubtitleLanguage = values[3].ToString(),
                IsActive = values[4].StringToBoolean(),
                Duration = int.Parse(values[5].ToString())
            };
        }
    }
}
