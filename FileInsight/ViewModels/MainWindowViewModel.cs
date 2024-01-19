using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using FileInsight.Models;
using Prism.Mvvm;

namespace FileInsight.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        public string Title { get => title; set => SetProperty(ref title, value); }

        public ObservableCollection<ExFileInfo> FileInfos { get; set; } = new ();

        public void AddFile(string path)
        {
            var fi = Directory.Exists(path)
                ? new ExFileInfo(new DirectoryInfo(path))
                : new ExFileInfo(new FileInfo(path!));

            var f = FileInfos.FirstOrDefault(f => f.FullName == fi.FullName);
            if (f == null)
            {
                FileInfos.Add(fi);
            }
        }
    }
}