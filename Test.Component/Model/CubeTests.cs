using RubiksSharp.Model;
using RubiksSharp.Model.Data;
using RubiksSharp.Model.Implementation;
using System;
using System.Collections.Generic;
using Xunit;

namespace Test.Component
{
    public class CubeTests
    {

        [Fact]
        public void RoateCounterClockwiseThrowsAnArgumentNullExceptionWhenGivenNull()
        {
            var cube = new ThreeByThreeCube();

            Assert.Throws<ArgumentNullException>(() => cube.RotateCounterClockwise(null));
        }

        [Fact]
        public void RoateCounterClockwiseThrowsAninvalidOperationExceptionWhenTheFaceDoesNotBelongToTheCube()
        {
            var cube = new ThreeByThreeCube();

            Assert.Throws<InvalidOperationException>(() => cube.RotateCounterClockwise(new ThreeByThreeCubeFace(Color.White)));
        }

        [Fact]
        public void RoateClockwiseThrowsAnArgumentNullExceptionWhenGivenNull()
        {
            var cube = new ThreeByThreeCube();

            Assert.Throws<ArgumentNullException>(() => cube.RotateClockwise(null));
        }

        [Fact]
        public void RoateClockwiseThrowsAninvalidOperationExceptionWhenTheFaceDoesNotBelongToTheCube()
        {
            var cube = new ThreeByThreeCube();

            Assert.Throws<InvalidOperationException>(() => cube.RotateClockwise(new ThreeByThreeCubeFace(Color.White)));
        }

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

        [Fact]
        public void CanRotateFrontFaceClockwise()
        {
            var cube = new ThreeByThreeCube();

            cube.RotateClockwise(cube.FrontFace);

            // Assert reletive front face sides are in the correct configuration.
            Assert.Equal(new CubeRow(Color.Red, 3), cube.TopFace.BottomRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(Color.White, 3), cube.RightFace.LeftRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(Color.Yellow, 3), cube.LeftFace.RightRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(Color.Orange, 3), cube.BottomFace.TopRow, new CubeRowEqualityComparer());

            // Assert reletive backside of cube is untouched. 
            Assert.Equal(new CubeRow(Color.Yellow, 3), cube.BottomFace.BottomRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(Color.Orange, 3), cube.RightFace.RightRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(Color.Red, 3), cube.LeftFace.LeftRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(Color.White, 3), cube.TopFace.TopRow, new CubeRowEqualityComparer());

            // Side configurations are correct.

            //left
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Red), new Facelet(Color.Red), new Facelet(Color.Yellow) }), cube.LeftFace.TopRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Red), new Facelet(Color.Red), new Facelet(Color.Yellow) }), cube.LeftFace.BottomRow, new CubeRowEqualityComparer());

            //right
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.White), new Facelet(Color.Orange), new Facelet(Color.Orange) }), cube.RightFace.TopRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.White), new Facelet(Color.Orange), new Facelet(Color.Orange) }), cube.RightFace.BottomRow, new CubeRowEqualityComparer());

            //top
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.White), new Facelet(Color.White), new Facelet(Color.Red) }), cube.TopFace.LeftRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.White), new Facelet(Color.White), new Facelet(Color.Red) }), cube.TopFace.RightRow, new CubeRowEqualityComparer());

            //bottom
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Orange), new Facelet(Color.Yellow), new Facelet(Color.Yellow) }), cube.BottomFace.LeftRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Orange), new Facelet(Color.Yellow), new Facelet(Color.Yellow) }), cube.BottomFace.RightRow, new CubeRowEqualityComparer());
        }
    }
}
