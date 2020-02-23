using RubiksSharp.Model.Implementation;
using RubiksSharp.Viewer.ViewModels;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RubiksSharp.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CubeViewModel cubeViewModel;

        public MainWindow()
        {
            InitializeComponent();

            var cube = new ThreeByThreeCube();
            cubeViewModel = new CubeViewModel(cube);

            //cube.RotateClockwise(cube.RightFace);   // R
            //cube.RotateClockwise(cube.FrontFace);   // F
            //cube.RotateClockwise(cube.LeftFace);    // L
            //cube.RotateClockwise(cube.LeftFace);    // L
            //cube.RotateClockwise(cube.RightFace);   // R
            //cube.RotateClockwise(cube.FrontFace);   // F
            //cube.RotateClockwise(cube.FrontFace);   // F
            //cube.RotateClockwise(cube.RightFace);   // R
            //cube.RotateClockwise(cube.BackFace);    // B
            //cube.RotateCounterClockwise(cube.BackFace); // B'
            //cube.RotateClockwise(cube.LeftFace);    // L
            //cube.RotateClockwise(cube.FrontFace);   // F
            //cube.RotateCounterClockwise(cube.RightFace); // R'
            //cube.RotateCounterClockwise(cube.LeftFace);    // L'
            //cube.RotateClockwise(cube.TopFace); // U
            //cube.RotateCounterClockwise(cube.RightFace); // R'
            //cube.RotateClockwise(cube.BottomFace); // D
            //cube.RotateCounterClockwise(cube.FrontFace);   // F'
            //cube.RotateCounterClockwise(cube.TopFace); // U'
            //cube.RotateCounterClockwise(cube.FrontFace);   // F'
            //cube.RotateCounterClockwise(cube.TopFace); // U'

            BindFace(frontFace, cubeViewModel.FrontFace);
            BindFace(backFace, cubeViewModel.BackFace);
            BindFace(leftFace, cubeViewModel.LeftFace);
            BindFace(rightFace, cubeViewModel.RightFace);
            BindFace(topFace, cubeViewModel.TopFace);
            BindFace(bottomFace, cubeViewModel.BottomFace);

            //// Solve
            //cubeViewModel.RotateCounterClockwise(cubeViewModel.RightFace); // R'
            //cubeViewModel.RotateClockwise(cubeViewModel.TopFace);     // U
            //cubeViewModel.RotateClockwise(cubeViewModel.LeftFace);    // L
            //cubeViewModel.RotateClockwise(cubeViewModel.LeftFace);    // L
            //cubeViewModel.RotateClockwise(cubeViewModel.TopFace);     // U
            //cubeViewModel.RotateClockwise(cubeViewModel.RightFace);   // R
            //cubeViewModel.RotateClockwise(cubeViewModel.RightFace);   // R
            //cubeViewModel.RotateClockwise(cubeViewModel.FrontFace);   // F
            //cubeViewModel.RotateClockwise(cubeViewModel.BackFace);    // B
            //cubeViewModel.RotateClockwise(cubeViewModel.BackFace);    // B
            //cubeViewModel.RotateCounterClockwise(cubeViewModel.RightFace);    // R'
            //cubeViewModel.RotateCounterClockwise(cubeViewModel.TopFace);      // U'
            //cubeViewModel.RotateCounterClockwise(cubeViewModel.LeftFace);     // L'
            //cubeViewModel.RotateClockwise(cubeViewModel.TopFace);     // U
            //cubeViewModel.RotateClockwise(cubeViewModel.RightFace);   // R
            //cubeViewModel.RotateClockwise(cubeViewModel.RightFace);   // R
            //cubeViewModel.RotateClockwise(cubeViewModel.FrontFace);   // F
            //cubeViewModel.RotateClockwise(cubeViewModel.FrontFace);   // F
            //cubeViewModel.RotateClockwise(cubeViewModel.BottomFace);  // D
            //cubeViewModel.RotateClockwise(cubeViewModel.BackFace);    // B
            //cubeViewModel.RotateClockwise(cubeViewModel.BackFace);    // B
            //cubeViewModel.RotateClockwise(cubeViewModel.BottomFace);  // D
            //cubeViewModel.RotateClockwise(cubeViewModel.BottomFace);  // D 
            //cubeViewModel.RotateClockwise(cubeViewModel.BackFace);    // B
            //cubeViewModel.RotateClockwise(cubeViewModel.BackFace);    // B
            //cubeViewModel.RotateCounterClockwise(cubeViewModel.TopFace);  // U'
            //cubeViewModel.RotateClockwise(cubeViewModel.FrontFace);   // F
            //cubeViewModel.RotateClockwise(cubeViewModel.FrontFace);   // F
            //cubeViewModel.RotateClockwise(cubeViewModel.BottomFace);  // D
        }

        private void BindFace(UniformGrid gridFace, FaceViewModel face)
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

        // TODO: Command pattern.

        private void RotateF_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateClockwise(cubeViewModel.FrontFace);
        }

        private void RotateFP_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateCounterClockwise(cubeViewModel.FrontFace);
        }

        private void RotateL_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateClockwise(cubeViewModel.LeftFace);
        }

        private void RotateLP_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateCounterClockwise(cubeViewModel.LeftFace);
        }

        private void RotateR_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateClockwise(cubeViewModel.RightFace);
        }

        private void RotateRP_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateCounterClockwise(cubeViewModel.RightFace);
        }

        private void RotateU_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateClockwise(cubeViewModel.TopFace);
        }

        private void RotateUP_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateCounterClockwise(cubeViewModel.TopFace);
        }

        private void RotateD_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateClockwise(cubeViewModel.BottomFace);
        }

        private void RotateDP_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateCounterClockwise(cubeViewModel.BottomFace);
        }

        private void RotateB_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateClockwise(cubeViewModel.BackFace);
        }

        private void RotateBP_Click(object sender, RoutedEventArgs e)
        {
            cubeViewModel.RotateCounterClockwise(cubeViewModel.BackFace);
        }
    }
}
