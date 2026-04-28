using Domain;

namespace Infrastucture;

public interface IMoviess
{
     List<Movies> GetAllMovies();
    Movies? GetMovieById(int id);
    void AddMovieById(int id);
    void UpdateMOvies(Movies movies);
    void DeleteMovieById(int id);
}


