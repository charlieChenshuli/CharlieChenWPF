/*
   In App.xaml:
   <Application.Resources>
       <vm:ViewModelLocator xmlns:vm="clr-namespace:MVVMLightDemo"
                            x:Key="Locator" />
   </Application.Resources>
   In the View:
   DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
   You can also use Blend to do all this with the tool's support.
   See http://www.galasoft.ch/mvvm
 */

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
namespace ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            #region Code Example
            if (ViewModelBase.IsInDesignModeStatic)
            {

                // Create design time view services and models
                SimpleIoc.Default.Register<MainViewModel>();

            }
            else
            {
                SimpleIoc.Default.Register<MainViewModel>();
                // Create run time view services and models

            }
            #endregion
           

        }
        #region ʵ����
        public MainViewModel mainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        #endregion
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
