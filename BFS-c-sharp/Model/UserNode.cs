using System;
using System.Collections.Generic;

namespace BFS_c_sharp.Model
{
    public class UserNode
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly HashSet<UserNode> _friends = new HashSet<UserNode>();

        public HashSet<UserNode> Friends
        {
            get { return _friends; }
        }


        public UserNode() { }

        public UserNode(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = Guid.NewGuid();
        }

        public void AddFriend(UserNode friend)
        {
            Friends.Add(friend);
            friend.Friends.Add(this);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "(" + Friends.Count + ")";
        }

        public static int DistanceBetweenUsers(UserNode user1, UserNode user2)
        {
            Queue<UserNode> userQueue = new Queue<UserNode>();
            userQueue.Enqueue(user1);
            int distance = 1;
            while(userQueue.Count != 0)
            {
                var dequeued = userQueue.Dequeue();
                Console.WriteLine(dequeued.FirstName +" " +  dequeued.LastName);
                Console.WriteLine("Distance: "+ distance +" ,Friends: ");
                foreach (var user in dequeued.Friends)
                {
                    Console.WriteLine("- "+user.FirstName + " " + user.LastName + ", Id:" + user.Id );
                    if (user.Id != dequeued.Id)
                    {
                        if (user.Id == user2.Id) return distance;
                        else
                        {
                            userQueue.Enqueue(user);
                        }
                    }
                }
                distance++;
            }
            return -1;
        }

        public HashSet<UserNode> FriendsOfFriends(int distance)
        {
            Queue<UserNode> userQueue = new Queue<UserNode>();
            userQueue.Enqueue(this);

            HashSet<UserNode> friendsOfFriends = new HashSet<UserNode>();



            throw new NotImplementedException();
        }



        static List<List<UserNode>> ShortestPathBetweenUsers(UserNode user1, UserNode user2)
        {
            Queue<UserNode> userQueue = new Queue<UserNode>();

            throw new NotImplementedException();
        }
    }
}
