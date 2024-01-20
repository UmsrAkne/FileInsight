using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using FileInsight.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace FileInsight.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";
        private ExFileInfo selectedItem;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public ObservableCollection<ExFileInfo> FileInfos { get; set; } = new ();

        public ExFileInfo SelectedItem { get => selectedItem; set => SetProperty(ref selectedItem, value); }

        public DelegateCommand CopyPathCommand => new (() =>
        {
            if (SelectedItem == null)
            {
                return;
            }

            Clipboard.SetText(SelectedItem.FullName);
        });

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