using Npgsql;
using Dapper;
using Domain;

using  Infrastucture;



MovieService service = new MovieService();

while (true)
{
    Console.WriteLine("\n===== MOVIE MENU =====");
    Console.WriteLine("1. Show All Movies");
    Console.WriteLine("2. Add Movie");
    Console.WriteLine("3. Get By Id");
    Console.WriteLine("4. Delete Movie");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            var movies = service.GetAllMovies();

            foreach (var m in movies)
                Console.WriteLine($"{m.Id} | {m.Title} | {m.Director} | {m.Year}");
            break;

        case "2":
            Movies newMovie = new Movies();

            Console.Write("Title: ");
            newMovie.Title = Console.ReadLine();

            Console.Write("Director: ");
            newMovie.Director = Console.ReadLine();

            Console.Write("Year: ");
            newMovie.Year = int.Parse(Console.ReadLine());

            service.AddMovieById(newMovie);
            Console.WriteLine("Movie added!");
            break;

        case "3":
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());

            var movie = service.GetMovieById(id);

            if (movie != null)
                Console.WriteLine($"{movie.Id} | {movie.Title} | {movie.Director} | {movie.Year}");
            else
                Console.WriteLine("Movie not found!");
            break;

        case "4":
            Console.Write("Enter Id: ");
            int delId = int.Parse(Console.ReadLine());

            service.DeleteMovieById(delId);
            Console.WriteLine("Movie deleted!");
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Wrong choice!");
            break;
    }
}