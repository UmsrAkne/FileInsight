using System;
using System.IO;
using Prism.Mvvm;

namespace FileInsight.Models
{
    public class ExFileInfo : BindableBase
    {
        public ExFileInfo(FileSystemInfo fileOrDirectory)
        {
            FileSystemInfo = fileOrDirectory;
            IsDirectory = Directory.Exists(fileOrDirectory.FullName);
            LoadedDateTime = DateTime.Now;
            FileType = IsDirectory ? "dir" : fileOrDirectory.Extension;
            FullName = fileOrDirectory.FullName;
            Name = fileOrDirectory.Name;
        }

        public FileSystemInfo FileSystemInfo { get; set; }

        public bool IsDirectory { get; private set; }

        public DateTime LoadedDateTime { get; set; }

        public string FileType { get; private set; }

        public string FullName { get; private set; }

        public string Name { get; private set; }
    }
}