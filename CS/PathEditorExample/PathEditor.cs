using DevExpress.Mvvm;
using DevExpress.Xpf.Editors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace PathEditorExample
{
    public class PathEditor : TextEdit
    {
        public ICommand ChangePathItemCommand
        {
            get;
            set;
        }

        public ICommand GoToClickedItemPathCommand
        {
            get;
            set;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.EditValueChanged += OnEditValueChanged;
            PathItems = new ObservableCollection<PathItem>();
            RefreshPathItems(Text);
            ChangePathItemCommand = new DelegateCommand<SelectionChangedEventArgs>(ChangePathItem);
            GoToClickedItemPathCommand = new DelegateCommand<PathItem>(GoToClickedItemPath);
        }

        public void ChangePathItem(SelectionChangedEventArgs parameter)
        {
            ComboBox selector = (ComboBox)parameter.Source;
            PathItem pathItem = selector.DataContext as PathItem;
            if (pathItem == null)
                return;
            this.EditValue = pathItem.PathToFolder + selector.SelectedItem;
        }

        public void GoToClickedItemPath(PathItem item)
        {
            this.EditValue = item.PathToFolder;
        }

        void OnEditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            RefreshPathItems(Text);
        }

        bool lockTextPathItemsRefresh;
        void RefreshPathItems(string path)
        {
            if (lockTextPathItemsRefresh)
                return;
            lockTextPathItemsRefresh = true;
            string newPath = path;
            string fullPath = string.Empty;
            string[] folders = newPath.Split('\\');

            PathItems.Clear();
            foreach (string folder in folders)
            {
                string previousPath;
                if (string.IsNullOrEmpty(folder))
                    break;
                previousPath = fullPath;
                fullPath += folder + "\\";
                if (Directory.Exists(fullPath))
                    PathItems.Add(CreatePathItem(fullPath, folder));
                else
                {
                    EditValue = previousPath;
                    break;
                }
            }
            lockTextPathItemsRefresh = false;
        }

        PathItem CreatePathItem(string fullPath, string currentFolder)
        {
            PathItem pathItem = new PathItem() { SelectedFolder = currentFolder, PathToFolder = fullPath };
            int pathLength = fullPath.Length;

            pathItem.SubFolders = Directory.GetDirectories(fullPath).Select((folderPath) => folderPath.Substring(pathLength)).ToList<string>();
            return pathItem;
        }


        public ObservableCollection<PathItem> PathItems
        {
            get;
            set;
        }
    }



    public class PathItem : ViewModelBase
    {
        public string SelectedFolder
        {
            get { return GetProperty(() => SelectedFolder); }
            set { SetProperty(() => SelectedFolder, value); }
        }
        public string PathToFolder
        {
            get { return GetProperty(() => PathToFolder); }
            set { SetProperty(() => PathToFolder, value); }
        }
        public List<string> SubFolders
        {
            get { return GetProperty(() => SubFolders); }
            set { SetProperty(() => SubFolders, value); }
        }

    }


}
