using RubiksSharp.Model.Data;
using RubiksSharp.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RubiksSharp.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var cube = new ThreeByThreeCube();

            cube.RotateClockwise(cube.RightFace);   // R
            cube.RotateClockwise(cube.FrontFace);   // F
            cube.RotateClockwise(cube.LeftFace);    // L
            cube.RotateClockwise(cube.LeftFace);    // L
            cube.RotateClockwise(cube.RightFace);   // R
            cube.RotateClockwise(cube.FrontFace);   // F
            cube.RotateClockwise(cube.FrontFace);   // F
            cube.RotateClockwise(cube.RightFace);   // R
            cube.RotateClockwise(cube.BackFace);    // B
            cube.RotateCounterClockwise(cube.BackFace); // B'
            cube.RotateClockwise(cube.LeftFace);    // L
            cube.RotateClockwise(cube.FrontFace);   // F
            cube.RotateCounterClockwise(cube.RightFace); // R'
            cube.RotateCounterClockwise(cube.LeftFace);    // L'
            cube.RotateClockwise(cube.TopFace); // U
            cube.RotateCounterClockwise(cube.RightFace); // R'

            cube.RotateClockwise(cube.BottomFace); // D

            BindFace(frontFace, cube.FrontFace);
            BindFace(backFace, cube.BackFace);
            BindFace(leftFace, cube.LeftFace);
            BindFace(rightFace, cube.RightFace);
            BindFace(topFace, cube.TopFace);
            BindFace(bottomFace, cube.BottomFace);
        }

        private void BindFaceInReverse(UniformGrid gridFace, CubeFace backFace2)
        {
            for (var i = backFace2.Rows.Count - 1; i >= 0; i--)
            {
                var row = backFace2.Rows[i];

                for (var i2 = row.Facelets.Count - 1; i2 >= 0; i2--)
                {
                    var facelet = row.Facelets[i2];

                    var faceletColorBinding = new Binding("CurrentColor")
                    {
                        Source = facelet,
                        Mode = BindingMode.OneWay,
                        Converter = new FaceletConverter()
                    };

                    var faceletRectangle = new Rectangle()
                    {
                        Stroke = new SolidColorBrush(Colors.Black)
                    };

                    faceletRectangle.SetBinding(Shape.FillProperty, faceletColorBinding);
                    gridFace.Children.Add(faceletRectangle);
                }
            }
        }

        private void BindFace(UniformGrid gridFace, CubeFace face)
        {
            foreach (var row in face.Rows)
            {
                foreach (var facelet in row.Facelets)
                {
                    var faceletColorBinding = new Binding("CurrentColor")
                    {
                        Source = facelet,
                        Mode = BindingMode.OneWay,
                        Converter = new FaceletConverter()
                    };

                    var faceletRectangle = new Rectangle()
                    {
                        Stroke = new SolidColorBrush(Colors.Black)
                    };

                    faceletRectangle.SetBinding(Shape.FillProperty, faceletColorBinding);
                    gridFace.Children.Add(faceletRectangle);
                }
            }
        }
    }
}
