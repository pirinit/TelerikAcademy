using System;
using System.Collections.Generic;
using System.IO;

/* 2. Write a program to traverse the directory C:\WINDOWS
 * and all its subdirectories recursively and to display
 * all files matching the mask *.exe.
 * Use the class System.IO.Directory.
 */
namespace _2.DirectoryTraversal
{
    public class DirectoryTraversal
    {
        List<string> exeFiles = new List<string>();

        public static void Main()
        {
            string startDir = @"C:\windows";
            string pattern = @"*.exe";
            // simple solution
            //var matchedFiles = Directory.EnumerateFiles(startDir, pattern, SearchOption.AllDirectories);

            //foreach (var file in matchedFiles)
            //{
            //    Console.WriteLine(file);
            //}

            // other solution
            TraverseSubdirs(startDir, pattern);

            //both solutions will most likele throw an System.UnauthorizedAccessException
        }

        private static void TraverseSubdirs(string startDir, string pattern)
        {
            var matched = Directory.EnumerateFiles(startDir, pattern);
            foreach (var file in matched)
            {
                Console.WriteLine(file);
            }

            var subdirs = Directory.EnumerateDirectories(startDir);
            foreach (var dir in subdirs)
            {
                TraverseSubdirs(dir, pattern);
            }
        }
    }
}
