using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Part_One_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create obj to call the recipe class and all the methods in it to main
            //main is minimal and clean.
            Recipe rep = new Recipe();
            rep.welcomeMsg();
        }
    }
}
