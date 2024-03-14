using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CharlieWpfControl
{
    public class ArcScrollbar: ProgressBar
    {
        static ArcScrollbar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ArcScrollbar), new FrameworkPropertyMetadata(typeof(ArcScrollbar)));
        }
    }
}
