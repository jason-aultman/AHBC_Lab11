using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AHBC_Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            var max = Enum.GetNames(typeof(Catagory)).Length;  //get length of enum Catagory
            bool again = false;   //continuation variable for the do/while loop below

            Console.WriteLine("Welcome to the Movie List Application!\n\n");
            MakeList(movies);    //initialize a new list of Movies with 10 movies   
            do
            {
                Console.WriteLine($"There are {movies.Count} movies in the list.");
                DisplayCatagory(max);     //Display a menu of options
                var selection = GetUserInput(max);    //Get user input with parameter containing Max value for the options list
                DisplayMoviesByType(ReturnMoviesByType(selection, movies));  //gets a list of movies, alphabetizes list of selections, then displays that list to user
                again = DoAgain();   //Ask user to go again 
            } while (again);
            
        }

        private static bool DoAgain()
        {
            string userInput;
            do
            {
                Console.WriteLine("Would you like to go again? Yes, or No?");
                userInput = Console.ReadLine();

            } while (!Validator.ValidateYesOrNo(userInput));
            if (userInput.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }

        private static void DisplayMoviesByType(List<Movie> movies)
        {
            foreach(Movie movie in movies)
            {
               
                    Console.WriteLine($"{movie.Title}");
            }
        }
        public static List<Movie> AlphabatizeList(List<Movie> movies)
        {
            List<Movie> AlphabatizedList = movies.OrderBy(thing => thing.Title).ToList();
            return AlphabatizedList;
        }
        private static List<Movie> ReturnMoviesByType(int selection, List<Movie> movies)
        {
            List<Movie> selectedMovies = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Catagory == (Catagory)selection)
                {
                    selectedMovies.Add(movie);
                }
            }
            return AlphabatizeList(selectedMovies);
        }
        private static void DisplayCatagory(int max)
        {
            Console.WriteLine("What catagory would you like?  Your choices are:");
          
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine($"[{i}] {(Catagory)i}");
            }
        }

        private static int GetUserInput(int max)
        {
            int userInput = -1;
            do
            {
              userInput = Validator.ValidateAndReturnValidInt(0, max, Console.ReadLine());
            } while (userInput==-1);
            return userInput;

           
        }

        private static void MakeList(List<Movie> movies)
        {
            movies.Add(new Movie("Up", Catagory.animated));
            movies.Add(new Movie("Silence of the Lambs", Catagory.horror));
            movies.Add(new Movie("Alien", Catagory.scifi));
            movies.Add(new Movie("Avatar", Catagory.scifi));
            movies.Add(new Movie("Mulan", Catagory.animated));
            movies.Add(new Movie("Pulp Fiction", Catagory.drama));
            movies.Add(new Movie("Halloween", Catagory.horror));
            movies.Add(new Movie("The Simpsons Movie", Catagory.animated));
            movies.Add(new Movie("Star Trek", Catagory.scifi));
            movies.Add(new Movie("The Little Mermaid", Catagory.animated));
        }
        private static void DisplayMovies(List<Movie> movies)
        {
            Console.WriteLine("Your selections in alphabetical order are: ");
            foreach (Movie m in movies)
            {
                Console.WriteLine($"{m.Title} {m.Catagory}");
            }
        }
    }
}
