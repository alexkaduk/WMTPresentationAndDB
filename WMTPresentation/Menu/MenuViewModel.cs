using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using WMTPresentation.Views;

namespace WMTPresentation.Menu
{ 
    public class MenuViewModel : ViewModelBase
    {
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        private MenuItem selectedMenuItem;

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>(GetMenuItems());
            SelectedMenuItem = MenuItems.FirstOrDefault();
        }

        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { selectedMenuItem = value; RaisePropertyChanged(); }
        }

        private List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem() { Title = "Presentation", SymbolIcon = Symbol.Home, NavigateTo = typeof(PresentationPage) });
            menuItems.Add(new MenuItem() { Title = "Chapter", SymbolIcon = Symbol.OutlineStar, NavigateTo = typeof(ChapterPage) });
            menuItems.Add(new MenuItem() { Title = "Slide", SymbolIcon = Symbol.Map, NavigateTo = typeof(SlidePage) });

            return menuItems;
        }
    }
}
