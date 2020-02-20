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
            HashSet<UserNode> lookedAt = new HashSet<UserNode>() { user1 };
            userQueue.Enqueue(user1);
            int distance = 1;
            while (userQueue.Count != 0)
            {
                Console.WriteLine("Distance: " + distance);
                userQueue = GetFriends(userQueue, lookedAt);
                if (userQueue.Contains(user2)) return distance;
                distance++;
            }
            return -1;
        }

        public HashSet<UserNode> FriendsOfFriends(int distance)
        {
            Queue<UserNode> userQueue = new Queue<UserNode>();
            userQueue.Enqueue(this);
            HashSet<UserNode> lookedAt = new HashSet<UserNode>() { this };

            for(int i = 0; i< distance; i++)
            {
                userQueue = GetFriends(userQueue, lookedAt);
            }

            return new HashSet<UserNode>(userQueue);
        }



        static List<List<UserNode>> ShortestPathBetweenUsers(UserNode user1, UserNode user2)
        {
            throw new NotImplementedException();
        }

        static Queue<UserNode> GetFriends(Queue<UserNode> users, HashSet<UserNode> lookedAt)
        {
            Queue<UserNode> newQueue = new Queue<UserNode>();

            while (users.Count != 0)
            {
                var dequeued = users.Dequeue();
                lookedAt.Add(dequeued);
                Console.WriteLine(dequeued.FirstName + " " + dequeued.LastName);
                Console.WriteLine("Friends: ");
                foreach (var user in dequeued.Friends)
                {
                    if (!lookedAt.Contains(user))
                    {
                        Console.WriteLine("- " + user.FirstName + " " + user.LastName + ", Id:" + user.Id);
                        newQueue.Enqueue(user);

                    }
                }
            }

            return newQueue;
        }
    }
}
