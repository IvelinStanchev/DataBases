using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace _15_ValidatesXML
{
    class ValidatesXML
    {
        private static bool isValid = true;

        static void Main()
        {
            string xsdFilePath = "../../CatalogueSchema.xsd";
            string validXmlFilePath = "../../../Catalogue.xml";
            string invalidXmlFilePath = "../../../InvalidCatalogue.xml";

            ValidateXmlAgainstXSD(xsdFilePath, validXmlFilePath);
            ValidateXmlAgainstXSD(xsdFilePath, invalidXmlFilePath);
        }

        private static void ValidateXmlAgainstXSD(string xsdFilePath, string xmlFilePath)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdFilePath);
            settings.ValidationType = ValidationType.Schema;

            XmlDocument document = new XmlDocument();
            document.Load(xmlFilePath);
            XmlReader rdr = XmlReader.Create(new StringReader(document.InnerXml), settings);

            try
            {
                while (rdr.Read())
                {

                }
            }
            catch(XmlSchemaValidationException e)
            {
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("The document {0} validated against {1} is valid.", xmlFilePath, xsdFilePath);
            }
            else
            {
                Console.WriteLine("The document {0} validated against {1} is not valid.", xmlFilePath, xsdFilePath);
            }
        }
    }
}
