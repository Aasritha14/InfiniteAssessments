using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
     public class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Actor { get; set; }
        public string Actress { get; set; }
        public int YOR { get; set; }
    }
    internal class Linq_Assignment
    {

        List<Movies> li = new List<Movies>()
    {
        new Movies(){ MovieId=100, MovieName="Bahubali", Actor="Prabhas",Actress="Tamanna", YOR=2015 },
        new Movies(){ MovieId=200, MovieName="Bahubali2", Actor="Prabhas",Actress="Anushka", YOR=2017 },
        new Movies(){ MovieId=300, MovieName="Robot", Actor="Rajini",Actress="Aish", YOR=2010 },
        new Movies(){ MovieId=400, MovieName="3 idiots", Actor="Amir",Actress="kareena", YOR=2009 },
        new Movies(){ MovieId=500, MovieName="Saaho", Actor="Prabhas",Actress="shraddha", YOR=2019 },
    };

        //1. display list of movienames acted by prabhas 

        public void MovieNames()
        {
            var res = from m in li
                      where m.Actor == "Prabhas"
                      select m.MovieName;

            foreach (var movie in res)
            {
                Console.WriteLine(movie);
            }

        }

        //2. display list of all movies released in year 2019
        public void MovieRelease()
        {
            var res = from m in li

                      where m.YOR == 2019
                      select m.MovieName;

            foreach (var movie in res)
            {
                Console.WriteLine(movie);
            }
        }

        //3. display the list of movies who acted together by prabhas and anushka 
        public void MoviesActedTogether()
        {
            var res = from m in li
                      where m.Actor == "Prabhas" && m.Actress == "Anushka"
                      select m.MovieName;

            foreach (var movie in res)
            {
                Console.WriteLine(movie);
            }
        }

        //4. display the list of all actress who acted with prabhas 
        public void AllActress()
        {
            var res = from m in li
                      where m.Actor == "Prabhas" 
                      select m.Actress;

            foreach (var actress in res)
            {
                Console.WriteLine(actress);
            }
        }

        //5. display the list of all moves released from 2010 - 2018
        public void MoviesFrom()
        {
            var res = from m in li
                      where m.YOR >=2010 && m.YOR <= 2019
                      select m.MovieName;

            foreach(var movie in res)
            {
                Console.WriteLine(movie);
            }
        }

        //6. sort YOR in descending order and display all its records

        public void YORinDesc()
        {
            var res = from m in li
                      orderby m.YOR descending
                      select m;

            foreach (var movie in res)
            {
                Console.WriteLine($"{movie.MovieId} {movie.MovieName} {movie.Actor} {movie.Actress} {movie.YOR}");
            }
        }

        //7. display max movies acted by each actor 

        public void MaxMovies()
        {
            var res = from m in li
                      group m by m.Actor into g
                      select new
                      {
                          Actor = g.Key,
                         Count = g.Count()
                      };
            foreach (var item in res)
            {
                Console.WriteLine($"{item.Actor} acted in {item.Count} movies");
            }
        }

        //8. display the name of all movies which is 5 characters long 

        public void MovieCharacters()
        {
            var res = from m in li
                      where m.MovieName.Length == 5
                      select m.MovieName;

            foreach (var movie in res)
            {
                Console.WriteLine(movie);
            }
        }

        //9.display names of actor and actress where movie released in 
        //year 2017, 2009 and 2019
        public void MoviesReleasedInYear()
        {
            var res = from m in li
                      where m.YOR == 2017 || m.YOR == 2009 || m.YOR == 2019
                      select new
                      {
                          m.Actor,
                          m.Actress,
                          m.YOR
                      };

            foreach (var item in res)
                Console.WriteLine($"{item.Actor} {item.Actress} {item.YOR}");
        }

        //10.display the name of movies which start with 'b' and ends with 'i' 
        public void MoviesStartsWith()
        {
            var res = from m in li
                      where m.MovieName.StartsWith("B") && m.MovieName.EndsWith("I")
                      select m.MovieName;

            foreach(var movie in res)
            {
                Console.WriteLine(movie);
            }
        }

        //11.display name of actress who not acted with Rajini and print in descending 
        //order

        public void ActressNotActed()
        {
            var res = from m in li
                      where m.Actor != "Rajini"
                      orderby m.Actress descending
                      select m.Actress;

            foreach (var actress in res)
            {
                Console.WriteLine(actress);
            }
        }

        //12. display records in following format 

               // eg: 
              //movie name     cast
             //Bahubali     prabhas-tammanna

        public void DisplayRecords()
        {
            var res = from m in li
                      select new
                      {
                          m.MovieName,
                          Cast = m.Actor + " - " + m.Actress
                      };

            foreach(var item in res)
            {
                Console.WriteLine("Movie Name");
                Console.WriteLine(item.MovieName);
                Console.WriteLine("Cast" + item.Cast);
                
            }
        }
    }
}
