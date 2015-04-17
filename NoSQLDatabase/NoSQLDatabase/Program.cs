using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoSQLDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string selection = "-1";
            while (selection != "0")
            {
                Console.WriteLine("Enter 1 to create a store");
                Console.WriteLine("Enter 2 to create a document");
                Console.WriteLine("Enter 3 to read a document");
                Console.WriteLine("Enter 0 to exit");
                selection = Console.ReadLine();
                string storeName;
                string documentName;
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Name your store");
                        storeName = Console.ReadLine();
                        CreateStore(storeName);
                        break;
                    case "2":
                        Console.WriteLine("Name your document");
                        documentName = Console.ReadLine();
                        Console.WriteLine("Which store?");
                        storeName = Console.ReadLine();
                        Console.WriteLine("Document");
                        var value = Console.ReadLine();
                        CreateDocument(documentName,value,storeName);
                        break;
                    case "3":
                        Console.WriteLine("Which document");
                        documentName = Console.ReadLine();
                        Console.WriteLine("Which store?");
                        storeName = Console.ReadLine();
                        Console.WriteLine(LoadData(documentName, storeName));
                        break;
                    default:
                        Console.WriteLine("Ok Thanks");
                        break;
                }
            }
        }

        static void CreateStore(string storeName)
        {
            var pathString = @"C:\temp\" + storeName;
            System.IO.Directory.CreateDirectory(pathString);
        }

        static string LoadData(string fileName, string storeName)
        {
            string content;
            var filePath = @"C:\temp\" + storeName + @"\" + fileName + ".bin";
            using (var binReader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                content = binReader.ReadString();
            }

            return content;
            
        }
        static void CreateDocument(string key, string value,  string storeName)
        {
            //write document contents to file
            WriteToFile(value, key, storeName);
        }

        static void WriteToFile(string content, string fileName, string storeName)
        {
            try
            {
                var filePath = @"C:\temp\" + storeName + @"\" + fileName + ".bin";

                using (var binWriter =
                    new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                   binWriter.Write(content);
                }
                Console.WriteLine("Data Written!");
                Console.WriteLine();
            }
            catch (IOException ioexp)
            {
                Console.WriteLine("Error: {0}", ioexp.Message);
            }

        }
    }
}
