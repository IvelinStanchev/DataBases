using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace _14_ApplyTheStylesheetOnCatalogue
{
    class ApplyTheStylesheetOnCatalogue
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../13-XSLStylesheet/catalogue.xsl");
            xslt.Transform("../../../Catalogue.xml", "../../Catalogue.html");
        }
    }
}
