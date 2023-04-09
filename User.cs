//CPRG-211-F Object Oriented Programming
//Group 7: Guntas Dhaliwal and John Holloway
//Assignment 3: Singly Linked Lists, Serialization and Testing


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_skeleton
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password;

        //Initializes a User object.
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        //Gets the users ID.
        public int getId()
        {
            return Id;
        }

        //Gets the users name.
        public string getName()
        {
            return Name;
        }

        //Gets the users email.
        public string getEmail()
        {
            return Email;
        }

        //Checks if the passed password is correct.
        public bool isCorrectPassword(string password)
        {
            if (Password == null && password == null)
                return true;
            else if (Password == null || password == null)
                return false;
            else
                return Password.Equals(password);
        }

        //Checks if object is equal to another object.
        public bool equals(Object obj)
        {
            if (!(obj is User))
			return false;

            User other = (User)obj;

            return Id == other.Id && Id.Equals(other.Name) && Id.Equals(other.Email);
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Email: {Email}, Password: {Password}";
        }
    }
}
