using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratML.Core
{
    public static class XMLHelper
    {
        public static T? Deserialize<T>(string xml)
            where T : class
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.StringReader reader = new System.IO.StringReader(xml))
            {
                return serializer.Deserialize(reader) as T;
            }
        }
    }
}
