using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var entities = new Entities();
            foreach (var user in entities.users)
                Console.WriteLine(user.name);
        }
    }
}
