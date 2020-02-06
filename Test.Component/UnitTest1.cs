using RubiksSharp.Model.Implementation;
using Xunit;

namespace Test.Component
{
    public class CubeTests
    {
        [Fact]
        public void CanRotateReletiveCubeFaces()
        {
            var cube = new ThreeByThreeCube();

            cube.RotateClockwise(cube.FrontFace);
            cube.RotateCounterClockwise(cube.FrontFace);

            Assert.True(cube.IsSolved);

            cube.RotateClockwise(cube.BackFace);
            cube.RotateCounterClockwise(cube.BackFace);

            Assert.True(cube.IsSolved);

            cube.RotateClockwise(cube.LeftFace);
            cube.RotateCounterClockwise(cube.LeftFace);

            Assert.True(cube.IsSolved);

            cube.RotateClockwise(cube.RightFace);
            cube.RotateCounterClockwise(cube.RightFace);

            Assert.True(cube.IsSolved);

            cube.RotateClockwise(cube.TopFace);
            cube.RotateCounterClockwise(cube.TopFace);

            Assert.True(cube.IsSolved);

            cube.RotateClockwise(cube.BottomFace);
            cube.RotateCounterClockwise(cube.BottomFace);

            Assert.True(cube.IsSolved);
        }
    }
}
