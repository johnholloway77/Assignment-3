using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment_3_skeleton
{
    public static class SerializationHelper
    {
        public static void SerializeUsers(List<User> users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate);
            
            serializer.WriteObject(stream, users);

            stream.Close();
        }

        public static List<User> DeserializeUsers(string fileName)
        {
            
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            FileStream stream = File.OpenRead(fileName);

            List<User> users = (List<User>)serializer.ReadObject(stream);
            
            stream.Close();

            return users;
        }




    }
 }
