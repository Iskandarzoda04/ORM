using Npgsql;
using Dapper;
using Domain;

namespace Infrastucture;

public class MovieService : IMoviess
{
    public  string connectionString =
        "Server=localhost;Database=date;User Id=postgres;Password=12345";
   


    public void AddMovieById(int id)
    {

        using var con = new NpgsqlConnection(connectionString);
        con.Open();

        
    string sql = @"insert into moviess (title, director, year)
                   values (@title, @director, @year)";

    con.Execute(sql);
    }

    public object AddMovieById(int v, object id)
    {
        throw new NotImplementedException();
    }

    public void AddMovieById(object id)
    {
        throw new NotImplementedException();
    }

    public void DeleteMovieById(int id)
    {
            using var con = new NpgsqlConnection(connectionString);
            con.Open();

            var sql = $"delete from  moviess where id @id";
            con.Execute(sql, new {id =@id});

             con.Execute(sql);

    }
    

    public List<Movies> GetAllMovies()
    {
        using var con  = new NpgsqlConnection(connectionString);
        con.Open();

        string sql = "Select * from moviess";

       var  movies  = con.Query<Movies>(sql).ToList();

       return  movies;


    }

    public Movies? GetMovieById(int id)
    {
        Movies movies = new Movies();
        using var con  = new NpgsqlConnection(connectionString);
        con.Open();

        string sql = "Select * from moviess  where id=@id";
        var movie = con.QueryFirstOrDefault<Movies?>(sql, new {id = id});

        return movie;

    }

    public void UpdateMOvies(Movies movies)
    {
         using var con  = new NpgsqlConnection(connectionString);
        con.Open();
        
        if(string.IsNullOrWhiteSpace(movies.Title));
        {
            System.Console.WriteLine("Title name is erore");
            return;
        }

         var sql = $"update moviess  set Title=@title, Director =@dir, Year =@year";

         con.Execute(sql, movies);
           
    }

}
