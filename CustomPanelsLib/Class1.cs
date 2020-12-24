using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomPanelsLib
{
    public class CustomCanvas : Canvas
    {
        public static DependencyProperty currentColorProperty;

        static CustomCanvas()
        {
            currentColorProperty =
                DependencyProperty.Register(
                    "currentColor"
                    , typeof(string)
                    , typeof(CustomCanvas));
        }

        public string currentColor
        {
            get
            {
                return (string)GetValue(currentColorProperty);
            }
            set
            {
                SetValue(currentColorProperty, value);
            }
        }
    }
}
