using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MountBladeModPacker
{
    [XmlRoot("MBModPackProfile")]
    public class MBModPackProfile
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("baseDir")]
        public string BaseDir { get; set; }

        [XmlAttribute("saveDir")]
        public string SaveDir { get; set; }

        [XmlArray("ExcludeList")]
        [XmlArrayItem("ExcludeItem")]
        public List<MBModPackProfileExcludeItem> ExcludeList { get; set; }

        public MBModPackProfile()
        {
            ExcludeList = new List<MBModPackProfileExcludeItem>();
        }

        public static MBModPackProfile Load(string xmlFile)
        {
            using (StreamReader sr = new StreamReader(xmlFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MBModPackProfile));
                MBModPackProfile mbModPackProfileObj = serializer.Deserialize(sr) as MBModPackProfile;
                return mbModPackProfileObj;
            }
        }

        public void Save(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                File.Delete(xmlFile);
            }
            using (StreamWriter sw = new StreamWriter(xmlFile))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(MBModPackProfile));
                serializer.Serialize(sw, this);
            }
        }
    }


    [XmlRoot("ExcludeItem")]
    public class MBModPackProfileExcludeItem
    {
        [XmlAttribute("type")]
        public FolderFileType Type { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}
