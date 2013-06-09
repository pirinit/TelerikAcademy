using System.Collections.Generic;

namespace _3.DirectoryTree
{
    public class Folder
    {
        public List<File> Files { get; set; }
        public List<Folder> Folders { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }

        public long Size 
        {
            get
            {
                return CalcFolderSize();
            }
        }

        public Folder(string path, string name)
        {
            this.Name = name;
            this.Path = path;
        }

        private long CalcFolderSize()
        {
            long size = 0;

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var folder in this.Folders)
            {
                size += folder.Size;
            }

            return size;
        }
    }
}