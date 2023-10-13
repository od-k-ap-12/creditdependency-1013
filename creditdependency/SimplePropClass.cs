using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace creditdependency
{
    class SimplePropClass : FrameworkElement
    {
        static FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(
            new PropertyChangedCallback(ChangedCallbackMethod), new CoerceValueCallback(CoerceValueCallbackMethod));

        public static readonly DependencyProperty MyDataProperty =
            DependencyProperty.Register("MyData",
            typeof(int),
            typeof(SimplePropClass),
            metadata,
            new ValidateValueCallback(ValidateValueCallbackMethod));

        public int MyData
        {
            get { return (int)GetValue(MyDataProperty); }
            set { SetValue(MyDataProperty, value); }
        }

        static object CoerceValueCallbackMethod(DependencyObject d, object baseValue)
        {
            return (int)baseValue * 2;
        }

        static bool ValidateValueCallbackMethod(object value)
        {
            if ((int)value < 0)
                return false;
            return true;
        }

        static void ChangedCallbackMethod(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Application.Current.MainWindow.Title = e.NewValue.ToString();
        }
    }
}
