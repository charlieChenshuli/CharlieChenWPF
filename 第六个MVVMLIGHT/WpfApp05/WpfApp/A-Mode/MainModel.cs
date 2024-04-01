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


        public class User : ObservableObject
        {
            private Int64 id;
            /// <summary>
            /// 用户地址
            /// </summary>
            public Int64 Id
            {
                get { return id; }
                set { id = value; RaisePropertyChanged(() => Id); }
            }

            private String name;
            /// <summary>
            /// 用户名称
            /// </summary>
            public String Name
            {
                get { return name; }
                set { name = value; RaisePropertyChanged(() => Name); }
            }

            private String age;
            /// <summary>
            /// 用户地址
            /// </summary>
            public String Age
            {
                get { return age; }
                set { age = value; RaisePropertyChanged(() => Age); }
            }

            public string dataGridBackGround;
            /// <summary>
            /// 用户地址
            /// </summary>
            public String DataGridBackGround
            {
                get { return dataGridBackGround; }
                set { dataGridBackGround = value; RaisePropertyChanged(() => DataGridBackGround); }
            }


        }

    }



}
