//CPRG-211-F Object Oriented Programming
//Group 7: Guntas Dhaliwal and John Holloway
//Assignment 3: Singly Linked Lists, Serialization and Testing



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;


namespace Assignment_3_skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {

        
            string testFileName = @"..\..\res\test_users.bin";
            

            List<User> usersList = new List<User>();

            SLL linkedList = new SLL();

            // Test Prepend
            linkedList.Prepend(new User(1, "Alice", "alice@example.com", "password1"));
            linkedList.Prepend(new User(2, "Bob", "bob@example.com", "password2"));
            linkedList.Prepend(new User(3, "Charlie", "charlie@example.com", "password3"));

            Console.WriteLine("Test Prepend, adding three usersto SLL");
            linkedList.print();

            // Test Append
            linkedList.Append(new User(4, "David", "david@example.com", "password4"));

            Console.WriteLine("\nTest append, adding David");
            linkedList.print();

            // Test Insert
            linkedList.Insert(new User(5, "Eve", "eve@example.com", "password5"), 2);

            Console.WriteLine("\nTest Insert, insert user Eve at the 3rd node in SLL");
            linkedList.print();

            // Test Replace
            linkedList.Replace(new User(6, "Frank", "frank@example.com", "password6"), 1);

            Console.WriteLine("\nTest Replace. Replacing user at second node with Frank:");
            linkedList.print();

            // Test Retrieve
            User userAtIndex = (User)linkedList.Retrieve(2);
            Console.WriteLine($"\nUser at index 2: {userAtIndex.Name}");


            // Test IndexOf
            int index = linkedList.IndexOf(userAtIndex);
            Console.WriteLine($"\nIndex of {userAtIndex.Name}: {index}");

            

            // Test Contains
            bool containsUser = linkedList.Contains(userAtIndex);
            Console.WriteLine($"\nList contains {userAtIndex.Name}: {containsUser}");

            

            // Test Size
            Console.WriteLine($"\nSize of the linked list: {linkedList.Size()}");

            

            // Test Delete
            linkedList.Delete(1);
            Console.WriteLine($"\nSize of the linked list after deleting User in node 1: {linkedList.Size()}");

            linkedList.print();


            //Test Serialization
            Console.WriteLine("\nTest serialization of SLL objects:");
            linkedList.serialize(testFileName);
            

            // Test Clear
            linkedList.Clear();
            Console.WriteLine($"Size of the linked list after clearing: {linkedList.Size()}");

            linkedList.print();

            //Test Deserialization
            Console.WriteLine("\nTest of deserialization of SLL objects");
            linkedList.deserialize(testFileName);
            Console.WriteLine($"Size of after deserializing objects from file: {linkedList.Size()}\n");

            linkedList.print();

            


            Console.WriteLine("\nPress any key to close program.");
            Console.ReadKey();
        }
    }
}
