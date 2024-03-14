using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Mode
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class MainModel : ObservableObject
    {
        private String textOne;
        /// <summary>
        /// 用户名称
        /// </summary>
        public String TextOne
        {
            get { return textOne; }
            set { textOne = value; RaisePropertyChanged(() => TextOne); }
        }

        private String textTwo;
        /// <summary>
        /// 用户地址
        /// </summary>
        public String TextTwo
        {
            get { return textTwo; }
            set { textTwo = value; RaisePropertyChanged(() => TextTwo); }
        }

        private String textResult;
        /// <summary>
        /// 用户地址
        /// </summary>
        public String TextResult
        {
            get { return textResult; }
            set { textResult = value; RaisePropertyChanged(() => TextResult); }
        }

    }
}
