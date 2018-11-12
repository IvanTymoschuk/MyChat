using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static DBase DBase = new DBase();
        static Repos<User> UserRepos = new Repos<User>(DBase);
        static Repos<Message> MessageRepos = new Repos<Message>(DBase);

        static void Main(string[] args)
        {
            UserRepos.


        }
    }
}
