using System;
using System.Collections.Generic;
using System.IO;

/* 3. Define classes File { string name, int size } and
 * Folder { string name, File[] files, Folder[] childFolders }
 * and using them build a tree keeping all files and folders
 * on the hard drive starting from C:\WINDOWS. Implement
 * a method that calculates the sum of the file sizes in
 * given subtree of the tree and test it accordingly.
 * Use recursive DFS traversal.
*/
namespace _3.DirectoryTree
{
    public class DirectoryTreeDemo
    {
        public static void Main()
        {
            Folder root = new Folder(@"D:\", "Dropbox");

            TraversFolder(root);

            Console.WriteLine(root.Size);
        }

        private static void TraversFolder(Folder folder)
        {
            string newPath = folder.Path + folder.Name;
            folder.Files = GetFiles(newPath);
            folder.Folders = GetFolders(newPath);
        }

        private static List<Folder> GetFolders(string path)
        {
            List<Folder> folders = new List<Folder>();
            var folderNames = Directory.GetDirectories(path);
            foreach (var folderName in folderNames)
            {
                DirectoryInfo di = new DirectoryInfo(folderName);
                Folder currentFolder = new Folder(di.FullName, di.Name);
                currentFolder.Files = GetFiles(folderName);
                currentFolder.Folders = GetFolders(folderName);
                folders.Add(currentFolder);
            }

            return folders;
        }

        private static List<File> GetFiles(string path)
        {
            List<File> files = new List<File>();
            var fileNames = Directory.GetFiles(path);
            foreach (var fileName in fileNames)
            {
                FileInfo fi = new FileInfo(fileName);

                File currentFile = new File(fi.Name, fi.Length);

                files.Add(currentFile);
            }

            return files;
        }
    }
}
