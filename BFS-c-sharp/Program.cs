using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Random rand = new Random();
            UserNode user1 = users.ElementAt(rand.Next(users.Count));
            UserNode user2 = users.ElementAt(rand.Next(users.Count));

            Console.WriteLine("\nUser1: " + user1 + ", User2: " + user2 + ", Distance: " + UserNode.DistanceBetweenUsers(user1, user2));



            Console.WriteLine("Done");
            Console.ReadKey();
        }





    }
}
