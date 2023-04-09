//CPRG-211-F Object Oriented Programming
//Group 7: Guntas Dhaliwal and John Holloway
//Assignment 3: Singly Linked Lists, Serialization and Testing


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    
    public class Node
    {
        
        public object Data { get; set; }
        
        public Node Next { get; set; }

        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }
    
    public class SLL : LinkedListADT
    {
        
        private Node head;
        
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }
        public void Append(object data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(object data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            count--;
        }

        public int IndexOf(object data)
        {
            int index = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public void Insert(object data, int index)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            Node newNode = new Node(data);
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            count++;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Prepend(object data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void Replace(object data, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = data;
        }

        public object Retrieve(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }



        public int Size()
        {
            return count;
        }

        public virtual void print()
        {
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                Console.WriteLine(tempNode.Data.ToString());
            }
        }

        public void serialize(string fileName)
        {
            Node current = head;
            List<User> users = new List<User>();
            while (current != null)
            {
                users.Add((User)current.Data);
                current = current.Next;
            }

            SerializationHelper.SerializeUsers(users, fileName);
            Console.WriteLine($"Users successfully serialized to {fileName}\n");

        }

        public void deserialize(string fileName)
        {
            //clear SLL so that deserialize doesn't add onto the existing SLL, but instead replaces it.
            this.Clear();

            List<User> users = SerializationHelper.DeserializeUsers(fileName);
            
            foreach (User user in users)
            {
                this.Append(user);
            }

            Console.WriteLine($"Users successfully deserialized from {fileName}\n");

        }

    }
}

