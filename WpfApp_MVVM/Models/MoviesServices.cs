using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp_MVVM.Models
{
    public class MoviesServices
    {
        TicketSalesSystemEntities2 ObjContext;
        public MoviesServices()
        {
            ObjContext = new TicketSalesSystemEntities2();
            
        }

        public List<MoviesDTO> GetAll()
        {
            List<MoviesDTO> ObjMoviesList = new List<MoviesDTO>();
            try
            {
                var ObjQuery = from movies in ObjContext.Movies select movies;
                foreach (var movie in ObjQuery)
                {
                    ObjMoviesList.Add(new MoviesDTO { Id = movie.Id, Genre = movie.genre, Timing = movie.timing,
                    Name = movie.name, Country = movie.country, Year = movie.year.ToString(), Director = movie.director, Release_date = movie.release_date.ToString(), Price = movie.price.ToString()
                    });
                }
             
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }
            return ObjMoviesList;
        }


        public bool Add(MoviesDTO objNewMovies)
        {
            bool IsAdded = false;
            if (string.IsNullOrWhiteSpace(objNewMovies.Genre))
            {
                Console.WriteLine("Genre is required.");
                return false;
            }

            try
            {
                var ObjMovies = new Movies();
                ObjMovies.Id = objNewMovies.Id;
                ObjMovies.genre = objNewMovies.Genre;
                ObjMovies.timing = objNewMovies.Timing;
                ObjMovies.name = objNewMovies.Name;
                // Преобразование строки year в int?
                if (int.TryParse(objNewMovies.Year, out int year))
                {
                    ObjMovies.year = year;
                }
                else
                {
                    ObjMovies.year = null; // или какое-то значение по умолчанию
                }
                ObjMovies.director = objNewMovies.Director;
                ObjMovies.country = objNewMovies.Country;
                if (DateTime.TryParse(objNewMovies.Release_date, out DateTime releaseDate))
                {
                    ObjMovies.release_date = releaseDate;
                }
                else
                {
                    ObjMovies.release_date = null; // или какое-то значение по умолчанию
                }
                
                // Преобразование строки price в decimal?
                if (decimal.TryParse(objNewMovies.Price, out decimal price))
                {
                    ObjMovies.price = price;
                }
                else
                {
                    ObjMovies.price = null; // или какое-то значение по умолчанию
                }

                ObjContext.Movies.Add(ObjMovies);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
              
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }


            return IsAdded;
        }

        public bool Update(MoviesDTO objMoviesToUpdate)
        {
            bool IsUpdated = false;


            try
            {
                var ObjMovies = ObjContext.Movies.Find(objMoviesToUpdate.Id);
                ObjMovies.genre = objMoviesToUpdate.Genre;
                ObjMovies.timing = objMoviesToUpdate.Timing;
                ObjMovies.name = objMoviesToUpdate.Name;
                // Преобразование строки year в int?
                if (int.TryParse(objMoviesToUpdate.Year, out int year))
                {
                    ObjMovies.year = year;
                }
                else
                {
                    ObjMovies.year = null; // или какое-то значение по умолчанию
                }
                ObjMovies.director = objMoviesToUpdate.Director;
                ObjMovies.country = objMoviesToUpdate.Country;
                if (DateTime.TryParse(objMoviesToUpdate.Release_date, out DateTime releaseDate))
                {
                    ObjMovies.release_date = releaseDate;
                }
                else
                {
                    ObjMovies.release_date = null; // или какое-то значение по умолчанию
                }

                // Преобразование строки price в decimal?
                if (decimal.TryParse(objMoviesToUpdate.Price, out decimal price))
                {
                    ObjMovies.price = price;
                }
                else
                {
                    ObjMovies.price = null; // или какое-то значение по умолчанию
                }

                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
              
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }


            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;


            try
            {
                var ObjMoviesToDelete = ObjContext.Movies.Find(id);
                ObjContext.Movies.Remove(ObjMoviesToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
              
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }


            return IsDeleted;
        }

        public MoviesDTO Search(int id)
        {
            MoviesDTO ObjMovies = null;

            try
            {
                var ObjMoviesToFind = ObjContext.Movies.Find(id);
                if (ObjMoviesToFind != null)
                {
                    ObjMovies = new MoviesDTO()
                    {
                        Genre = ObjMoviesToFind.genre,
                    Timing = ObjMoviesToFind.timing,
                    Name = ObjMoviesToFind.name,
                        Year = ObjMoviesToFind.year?.ToString(), // Преобразование int? в string
                        Director = ObjMoviesToFind.director,
                    Country = ObjMoviesToFind.country,
                        Release_date = ObjMoviesToFind.release_date?.ToString("yyyy-MM-dd"), // Преобразование DateTime? в string
                        Price = ObjMoviesToFind.price?.ToString() // Преобр
                    };
                }
            
            }
            catch (SqlException ex)
           {

                throw ex;
            }

            return ObjMovies;
        }
    }
}
