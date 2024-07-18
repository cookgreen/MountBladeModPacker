using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MountBladeModPacker
{
    public class FolderFile
    {
        public string Name { get; set; }
        public FolderFileType Type { get; set; }
    }

    public enum FolderFileType
    {
        Folder,
        File
    }
}
