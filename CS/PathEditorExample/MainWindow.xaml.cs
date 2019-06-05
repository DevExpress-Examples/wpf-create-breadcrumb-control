using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace PathEditorExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public class MainViewModel : ViewModelBase {

        public string Value {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }
        public ObservableCollection<Item> Items { get; set; }
        public MainViewModel() {
            Items = new ObservableCollection<Item>();
            for (int i = 0; i <= 20; i++)
                Items.Add(new Item() { Name = "Name_" + i, Value = i });
            for (int i = 0; i <= 20; i += 2)
                Items[i].Children = new List<Child>() {
                    new Child() { Name = "Child_" + i },
                      new Child() { Name = "Child_" + i+1 },
                        new Child() { Name = "Child_" + i+2 }
                };
        }
    }


    public class Item : BindableBase {
        public string Name {
            get { return GetProperty(() => Name); }
            set { SetProperty(() => Name, value); }
        }
        public int Value {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }
        public List<Child> Children {
            get { return GetProperty(() => Children); }
            set { SetProperty(() => Children, value); }
        }
    }

    public class Child
    {
        public string Name { get; internal set; }
    }
}
