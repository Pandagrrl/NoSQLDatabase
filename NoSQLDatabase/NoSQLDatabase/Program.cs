using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
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
                //Console.Write("Enter 3 to create a store"); 
                Console.WriteLine("Enter 0 to exit");
                selection = Console.ReadLine();
                string storeName;
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Name your store");
                        storeName = Console.ReadLine();
                        CreateStore(storeName);
                        break;
                    case "2":
                        Console.WriteLine("Name your document");
                        var documentName = Console.ReadLine();
                        Console.WriteLine("Which store?");
                        storeName = Console.ReadLine();
                        CreateDocument(documentName,storeName);
                        break;
                    default:
                        Console.WriteLine("Ok Thanks");
                        break;
                }
            }
           
            

        }

        static void CreateStore(string storeName)
        {
            WriteToFile("", storeName);
        }

        static void LoadData(string storeName)
        {
           //loop through list of documents in store and load content to collection
        }
        static void CreateDocument(string documentKey, string storeName)
        {
            //check if Json

            //add document name to store file
            WriteToFile(documentKey + "|", storeName);

            //write document contents to file
          
         
        }

        static void WriteToFile(string content, string fileName)
        {
            try
            {
                string filePath = @"C:\temp\" + fileName + ".bin";
                //BinaryWriter bwStream = new BinaryWriter(new FileStream(filePath, FileMode.Create));

                //Encoding ascii = Encoding.ASCII;
                //BinaryWriter bwEncoder = new BinaryWriter(new FileStream(filePath, FileMode.Create), ascii);

                using (BinaryWriter binWriter =
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
