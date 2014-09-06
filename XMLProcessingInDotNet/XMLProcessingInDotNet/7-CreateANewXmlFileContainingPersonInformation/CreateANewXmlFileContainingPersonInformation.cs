using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _7_CreateANewXmlFileContainingPersonInformation
{
    class CreateANewXmlFileContainingPersonInformation
    {
        static void Main()
        {
            string[] personInformation = File.ReadAllLines("../../personInformation.txt");

            string name = string.Empty;
            string address = string.Empty;
            string phoneNumber = string.Empty;

            for (int i = 0; i < personInformation.Length; i++)
            {
                string currentLine = personInformation[i];
                string[] objectAndValue = currentLine.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string objectName = objectAndValue[0];
                string objectValue = objectAndValue[1];
                if (objectName == "Name")
                {
                    name = objectValue;
                }
                else if (objectName == "Address")
                {
                    address = objectValue;
                }
                else
                {
                    phoneNumber = objectValue;
                }
            }

            XElement personXml = new XElement("people",
                new XElement("person",
                    new XElement("name", name),
                    new XElement("address", address),
                    new XElement("phone-number", phoneNumber)
                )
            );

            Console.WriteLine(personXml);

            personXml.Save("../../personDataAsXml.xml");
        }
    }
}
