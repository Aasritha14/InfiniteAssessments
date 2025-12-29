using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Linq_Assignment ob = new Linq_Assignment();

            ob.MovieNames();
            ob.MovieRelease();
            ob.MoviesActedTogether();
            ob.AllActress();
            ob.MoviesFrom();
            ob.YORinDesc();
            ob.MaxMovies();
            ob.MovieCharacters();
            ob.MoviesReleasedInYear();
            ob.MoviesStartsWith();
            ob.ActressNotActed();
            ob.DisplayRecords();

            Linq_Assignment_2 ob1 = new Linq_Assignment_2();
            ob1.SecondHighest();
            ob1.TopHighestprice();
            ob1.ProductName();
            ob1.FilterByCoulmnName();
            ob1.MaxOfPrice();

            Linq_Arrays ob2 = new Linq_Arrays();
            ob2.FecthUniqueValues();
            ob2.CombineValues();
            ob2.Commonitems();
            ob2.NamesPresent();
            ob2.SumOfPrice();
            ob2.CountOfProducts();
            ob2.HighestValueInListA();
            ob2.NumbersDivisibleBy3();
            ob2.Sort();

        }
    }
}
