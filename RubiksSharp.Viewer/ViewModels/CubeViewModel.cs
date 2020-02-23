namespace RubiksSharp.Viewer.ViewModels
{
    class CubeViewModel
    {
        private readonly Cube cube;

        public CubeViewModel(Cube cube)
        {
            this.cube = cube;
        }

        public void RotateClockwise(CubeFace face)
        {
            cube.RotateClockwise(face);
        }

        public void RotateCounterClockwise(CubeFace face)
        {
            cube.RotateCounterClockwise(face);
        }
    }
}
