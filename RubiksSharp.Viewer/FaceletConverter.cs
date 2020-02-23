using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RubiksSharp.Viewer
{
    class FaceletConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Model.Data.Color)value;
            var wpfColor = GetWpfColor(color);

            return new SolidColorBrush(wpfColor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;

            return GetRubiksSharpColor(color);
        }

        public Color GetWpfColor(Model.Data.Color color)
        {
            switch (color)
            {
                case Model.Data.Color.Blue:
                    return Colors.Blue;
                case Model.Data.Color.Orange:
                    return Colors.Orange;
                case Model.Data.Color.Green:
                    return Colors.Green;
                case Model.Data.Color.Red:
                    return Colors.Red;
                case Model.Data.Color.White:
                    return Colors.White;
                case Model.Data.Color.Yellow:
                    return Colors.Yellow;
                default:
                    return Colors.White;
            }
        }

        public Model.Data.Color GetRubiksSharpColor(Color color)
        {
            if (color == Colors.Blue)
            {
                return Model.Data.Color.Blue;
            } 
            else if (color == Colors.Orange)
            {
                return Model.Data.Color.Orange;
            }
            else if (color == Colors.Green)
            {
                return Model.Data.Color.Green;
            }
            else if (color == Colors.Wheat)
            {
                return Model.Data.Color.White;
            }
            else if (color == Colors.Yellow)
            {
                return Model.Data.Color.Yellow;
            }

            return Model.Data.Color.White;
        }
    }
}
