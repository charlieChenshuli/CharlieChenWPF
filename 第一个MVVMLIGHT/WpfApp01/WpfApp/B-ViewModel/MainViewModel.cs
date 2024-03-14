using GalaSoft.MvvmLight;
using Mode;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System;

namespace ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MainModelClass = new MainModel();
            MainModelClass.TextOne = " ";
            MainModelClass.TextTwo = " ";
            MainModelClass.TextResult = " ";
        }
        #region 属性
        private MainModel mainModel;
        /// <summary>
        /// 用户信息
        /// </summary>
        public MainModel MainModelClass
        {
            get { return mainModel; }
            set { mainModel = value; RaisePropertyChanged(() => MainModelClass); }
        }
        #endregion
        #region 命令
        #endregion

        public void AddButtonClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MainModelClass.TextResult = Convert.ToString(Convert.ToInt32(MainModelClass.TextOne.Trim()) + Convert.ToInt32(MainModelClass.TextTwo.Trim()));
            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
                
          
        }
    }
}