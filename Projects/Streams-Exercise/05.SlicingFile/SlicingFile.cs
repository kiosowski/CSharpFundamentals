﻿using System;
using System.Collections.Generic;
using System.IO;
namespace _05.SlicingFile
{
    class SlicingFile
    {
        private static List<string> files = new List<string>();
        static void Main(string[] args)
        {
            string source = @"D:\Георги\Software University\CSharpFundamentals\Projects\Streams-Exercise\Resourses\sliceMe.mp4";
            string destination = "";
            int parts = int.Parse(Console.ReadLine());
            Slice(source, destination, parts);
            string outputFileName = destination + "assembled.mp4";
            Assemble(files, outputFileName);
        }
        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source= new FileStream(sourceFile,FileMode.Open))
            {
                int fileLength = (int)(source.Length / parts);
                byte[] buffer = new byte[fileLength];
                int dotIndex = sourceFile.LastIndexOf('.');
                string fileExtansion = sourceFile.Substring(dotIndex);
                for (int i = 0; i < parts; i++)
                {
                    string file = destinationDirectory + "Part-" + i + fileExtansion;
                    using (var destination = new FileStream(file,FileMode.CreateNew))
                    {
                        int readBytes = source.Read(buffer, 0, fileLength);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                        files.Add(file);
                    }
                }
            }
        }
        private static void Assemble(List<string> files, string destinationDirectory)
        {
            using (var destination = new FileStream(destinationDirectory,FileMode.OpenOrCreate))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var source = new FileStream(files[i], FileMode.Open))
                    {
                        byte[] buffer = new byte[4069];
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }
                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
