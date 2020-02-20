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
            Console.WriteLine("Done");

            while (true)
            {
                Random rand = new Random();
                UserNode user1 = users.ElementAt(rand.Next(users.Count));
                UserNode user2 = users.ElementAt(rand.Next(users.Count));
                int distance = rand.Next(5);

                Console.WriteLine("\nUser1: " + user1 + ", User2: " + user2 + ", Distance: " + UserNode.DistanceBetweenUsers(user1, user2));
                Console.WriteLine("\nUser1: " + user1 + "Distance: " + distance + "\n Friends: ");
                foreach(var user in user1.FriendsOfFriends(distance))
                {
                    Console.WriteLine(user);
                }

                Console.WriteLine("Press escape to exit, anyhing else to rerun the functions");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) break;

            }
            
        }





    }
}
