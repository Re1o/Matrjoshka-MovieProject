using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Movie
{
    class Program
    {
        class MovieClass
        {
            string title;
            string director;
            string ratings;
            int userRating;

            public MovieClass(string _title, string _director, string _ratings, int _userRating)
            {
                title = _title;
                director = _director;
                Ratings = _ratings;
                UserRating = _userRating;
            }

            public string Ratings
            {
                get { return ratings; }
                set
                {
                    if (value == "G" || value == "PG" || value == "PG-13" || value == "R")
                    {
                        ratings = value;
                    }
                    else
                    {
                        ratings = "undefined";
                    }
                }
            }

            public int UserRating
            {
                get { return userRating; }
                set
                {
                    if (value >= 0 && value <= 10)
                    {
                        userRating = value;
                    }
                    else
                    {
                        userRating = 0;
                    }
                }
            }

            public string Title
            {
                get { return title; }
            }

            public string Director
            {
                get { return director; }
            }

        }
        static void Main(string[] args)
        {
            string filePath = @"C:\demo\Movies.txt";
            List<string> listFromFile = File.ReadAllLines(filePath).ToList();
            List<MovieClass> listOfMovies = new List<MovieClass>();

            foreach (string line in listFromFile)
            {


                string[] tempArray = line.Split('/');
                string tempTitle = tempArray[0];
                string tempDir = tempArray[1];
                string tempRatting = tempArray[2];
                int tempUserRating = int.Parse(tempArray[3]);

                MovieClass tempMovieObject = new MovieClass(tempTitle, tempDir, tempRatting, tempUserRating);
                listOfMovies.Add(tempMovieObject);

            }

            int i = 1;

            foreach (MovieClass movieObject in listOfMovies)
            {
                Console.WriteLine($"item {i}: {movieObject.Title} directed by {movieObject.Director}");
                i++;
            }


            Console.WriteLine("enter the key word: ");
            string userSearch = Console.ReadLine().ToLower();

            List<MovieClass> searchResult = new List<MovieClass>();

            //int searchResult = 0;
            foreach (MovieClass movieObject in listOfMovies)
            {
                if (movieObject.Title.ToLower().Contains(userSearch))
                {
                    //Console.WriteLine($"{movieObject.Title} directed by {movieObject.Director}");
                    searchResult.Add(movieObject);
                    // searchResult++;
                }
            }

            // Console.WriteLine($"{searchResult} movies found");

            Console.WriteLine($"{searchResult.Count} movies found");
            foreach (MovieClass movieObjects in searchResult)
            {
                Console.WriteLine($"{movieObjects.Title} directed by {movieObjects.Director}");
            }

        }
        
            
        
          
    }
}