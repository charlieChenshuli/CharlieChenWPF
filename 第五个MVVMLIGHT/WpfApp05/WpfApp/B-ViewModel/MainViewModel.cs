using GalaSoft.MvvmLight;
using Mode;
using System.Windows.Input;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Configurations;
using System.Threading;
using System.Threading.Tasks;

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
        
        public RelayCommand<RoutedEventArgs> AddButtonClick { get; set; }

        public RelayCommand<string> AddButtonTextClick { get; set; }

        public RelayCommand<RoutedEventArgs> GridAddButtonClick { get; set; }


        List<MainModel.User> _mylist = new List<MainModel.User>();
        public List<MainModel.User> Mylist
        {

            get { return _mylist; }
            set
            {
                _mylist = value;
                RaisePropertyChanged("mylist");
            }
        }

        public MainViewModel()
        {
            
            AddButtonClick = new RelayCommand<RoutedEventArgs>(AddButtonClickEvent);
            AddButtonTextClick = new RelayCommand<String>(AddButtonTextClickEvent);
            GridAddButtonClick = new RelayCommand<RoutedEventArgs>(GridAddButtonClickEvent);
            MainModelClass = new MainModel();
            MainModelClass.TextOne = "1234";
            MainModelClass.TextTwo = "1234";
            MainModelClass.TextResult = "1234";

            Mylist.Add(new MainModel.User() { Id = 0, Name = "张三", Age = "10", });
            Mylist.Add(new MainModel.User() { Id = 1, Name = "李四", Age = "20", });
            Mylist.Add(new MainModel.User() { Id = 2, Name = "王五", Age = "30", });
            Mylist.Add(new MainModel.User() { Id = 3, Name = "赵六", Age = "40", });
            for (int i = 4; i < 1000; i++)
            {

                Mylist.Add(new MainModel.User() { Id = i, Name = "张三", Age = "10", });
      
            }

            
            #region
            var mapper = Mappers.Xy<MeasureModel>()
            .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
            .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the values property will store our values array
            ChartValues = new ChartValues<MeasureModel>();

            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            //The next code simulates data changes every 300 ms

            IsReading = false;


            InjectStopOnClick();
            #endregion


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

        private  void AddButtonClickEvent(RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            MainModelClass.TextResult = Convert.ToString(Convert.ToInt32(MainModelClass.TextOne.Trim()) + Convert.ToInt32(MainModelClass.TextTwo.Trim()));
            MessageBox.Show("此按钮的内容" + b.Content);
            b.Background = Brushes.Green;
        }
        /// <summary>
        /// 带参数的命令
        /// </summary>
        /// <param name="obj"></param>
        private void AddButtonTextClickEvent(string obj)
        {
            MessageBox.Show("带的参数是第二个输入TEXTBOX的内容"+obj);
        }

        //public void AddButtonClickEvent(Button sender)
        //{
        //    try
        //    {
        //        MainModelClass.TextResult = Convert.ToString(Convert.ToInt32(MainModelClass.TextOne.Trim()) + Convert.ToInt32(MainModelClass.TextTwo.Trim()));
        //        object o = sender as Button;
        //    }
        //    catch (Exception E)
        //    {
        //        Console.WriteLine(E.Message);
        //    }


        //}

        public void AddTwoButtonClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MessageBox.Show("不带参数");
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }


        }

        /// <summary>
        /// 这样也可以
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void AddTwoButtonClick()
        //{
        //    try
        //    {
        //        MessageBox.Show("不带参数");
        //    }
        //    catch (Exception E)
        //    {
        //        Console.WriteLine(E.Message);
        //    }


        //}




        /// <summary>
        ///  这样不行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void AddTwoButtonClick(object sender)
        //{
        //    try
        //    {
        //        MessageBox.Show("不带参数");
        //    }
        //    catch (Exception E)
        //    {
        //        Console.WriteLine(E.Message);
        //    }


        //}



        /// <summary>
        /// DataTemplate.Button 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void GridAddButtonClickEvent(RoutedEventArgs e)
        {
            try
            {
                Button GridBtn = e.Source as Button;
                GridBtn.Background = Brushes.Red;
                //修改后台对象
                Mylist[Convert.ToInt32(GridBtn.Content)].Age = "GOGOGOG";

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }


        }

        /// <summary>
        /// DataTemplate.Button 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DataGridSelectedChanged(object sender, EventArgs e)
        {
           


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddRouteButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Grid grid = sender as Grid;
                foreach (var child in grid.Children)
                {
                    if (child is Button)
                    {
                        Button button = child as Button;
                        string name = button.GetValue(Button.ContentProperty).ToString();
                        if(e.Source is Button)

                        {
                            if (name == (e.Source as Button).Content.ToString())
                            {
                                (e.Source as Button).Background = Brushes.Red; 
                                //button.Background = Brushes.Red;
                            }
                        }

                      
                    }
                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }


        }



        #region
    
        private double _trend;

        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }



        private double _axisMin;
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                RaisePropertyChanged(() => AxisMin);
            }
        }
        private double _axisMax;
        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                RaisePropertyChanged(() => AxisMax);
            }
        }

        public bool IsReading { get; set; }

        private void Read()
        {
            var r = new Random();

            while (IsReading)
            {
                Thread.Sleep(500);
                var now = DateTime.Now;

                _trend = r.Next(-8, 10);

                ChartValues.Add(new MeasureModel
                {
                    DateTime = now,
                    Value = _trend
                });

                SetAxisLimits(now);

                //lets only use the last 150 values
                if (ChartValues.Count > 100) ChartValues.RemoveAt(0);


                //
                PieValue =  new Random().Next(50, 250);
            }
        }

        private void SetAxisLimits(DateTime now)
        {
            try
            {
                AxisMin = now.Ticks - TimeSpan.FromSeconds(10).Ticks; // and 8 seconds behind
                AxisMax = now.Ticks + TimeSpan.FromSeconds(10).Ticks; // lets force the axis to be 1 second ahead
            }
            catch
            {

            }
  

        }

        private void InjectStopOnClick()
        {
            IsReading = !IsReading;
            if (IsReading) Task.Factory.StartNew(Read);
        }

        #endregion


        #region
        private double _PieValue;
        public double PieValue
        {
            get { return _PieValue; }
            set
            {
                _PieValue = value;
                RaisePropertyChanged("PieValue");
            }
        }
        #endregion



    }


    public class MeasureModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
