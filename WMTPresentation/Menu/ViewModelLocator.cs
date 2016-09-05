using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace WMTPresentation.Menu
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MenuViewModel>();
        }

        public MenuViewModel MenuViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MenuViewModel>(); }
        }
    }
}
