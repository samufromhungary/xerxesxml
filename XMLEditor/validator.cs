using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XMLEditor
{
    public class Validator
    {
        public Validator()
        {

        }
        public bool Validate(String xsd, String xml)
        {
            bool isValid = false;
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", xsd);
            XDocument doc = XDocument.Load(xml);
            bool errors = false;
            doc.Validate(schemas, (o, e) =>
            {
                errors = true;
            });
            isValid = errors ? false : true;

            return isValid;
        }
    }
}
