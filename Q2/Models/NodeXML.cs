using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Q2.Models
{
    public class NodeXML
    {
        [XmlAttribute("id")]
        public int id { get; set; }

        [XmlElement("nome")]
        public string nome { get; set; }

        [XmlElement("entrada")]
        public string entrada { get; set; }

        [XmlElement("juros")]
        public string juros { get; set; }

        [XmlElement("periodo")]
        public string periodo { get; set; }

        [XmlElement("aporte")]
        public string aporte { get; set; }
    }
}