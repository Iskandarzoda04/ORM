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

//////////////////////////////////////////
static void CoursesMenu(CourseService service)
{
    Console.WriteLine("\n--- COURSES ---");
    Console.WriteLine("1. Add Course");
    Console.WriteLine("2. Get All Courses");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Course c = new Course();

        Console.Write("Title: ");
        c.Title = Console.ReadLine();

        Console.Write("Description: ");
        c.Description = Console.ReadLine();

        Console.Write("DurationWeeks: ");
        c.DurationWeeks = int.Parse(Console.ReadLine());

        service.Add(c);
    }
    else if (choice == 2)
    {
        var list = service.GetAll();

        foreach (var c in list)
            Console.WriteLine($"{c.CourseId} - {c.Title}");
    }
}
/////////
static void MentorsMenu(MentorService service)
{
    Console.WriteLine("\n--- MENTORS ---");
    Console.WriteLine("1. Add Mentor");
    Console.WriteLine("2. Get All Mentors");
    Console.WriteLine("3. Top Mentor");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 3)
    {
        var result = service.GetMentorWithMostStudents();
        Console.WriteLine(result);
    }
}

/////////////////////////////////////////////////////////////
/// 
/// 
static void GroupsMenu(GroupService service)
{
    Console.WriteLine("\n--- GROUPS ---");
    Console.WriteLine("1. Add Group");
    Console.WriteLine("2. Get Students Per Group");
    Console.WriteLine("3. Empty Groups");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 2)
    {
        var list = service.GetStudentsPerGroup();

        foreach (var g in list)
            Console.WriteLine(g);
    }
}