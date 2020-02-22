using RubiksSharp;
using RubiksSharp.Model.Data;
using RubiksSharp.Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Component.Utilities;
using Xunit;

namespace Test.Component
{
    public class FaceTests
    {
        [Fact]
        public void FrontOfFaceRotationsNegate()
        {
            var bottomFace = new ThreeByThreeCubeFace(Color.White);
            var topFace = new ThreeByThreeCubeFace(Color.White);
            var leftFace = new ThreeByThreeCubeFace(Color.White);
            var rightFace = new ThreeByThreeCubeFace(Color.White);
            var frontFace = new ThreeByThreeCubeFace(
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.White),
                    new Facelet(Color.Red),
                    new Facelet(Color.Orange)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Green),
                    new Facelet(Color.Blue),
                    new Facelet(Color.Yellow)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Blue),
                    new Facelet(Color.White),
                    new Facelet(Color.Red)
                }));

            MapFrontFace(frontFace.RotateClockwise, bottomFace, topFace, leftFace, rightFace);
            MapFrontFace(frontFace.RotateCounterClockwise, bottomFace, topFace, leftFace, rightFace);

            Assert.True(frontFace.IsSolved);
        }

        [Fact]
        public void FrontOfFaceCanRotateCouunterClockwise()
        {
            var bottomFace = new ThreeByThreeCubeFace(Color.White);
            var topFace = new ThreeByThreeCubeFace(Color.White);
            var leftFace = new ThreeByThreeCubeFace(Color.White);
            var rightFace = new ThreeByThreeCubeFace(Color.White);
            var frontFace = new ThreeByThreeCubeFace(
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.White),
                    new Facelet(Color.Red),
                    new Facelet(Color.Orange)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Green),
                    new Facelet(Color.Blue),
                    new Facelet(Color.Yellow)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Blue),
                    new Facelet(Color.White),
                    new Facelet(Color.Red)
                }));

            MapFrontFace(frontFace.RotateCounterClockwise, bottomFace, topFace, leftFace, rightFace);

            // Front of face rotated correctly.
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Orange), new Facelet(Color.Yellow), new Facelet(Color.Red) }), frontFace.TopRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Red), new Facelet(Color.Blue), new Facelet(Color.White) }), frontFace.MiddleRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.White), new Facelet(Color.Green), new Facelet(Color.Blue) }), frontFace.BottomRow, new CubeRowEqualityComparer());
        }

        [Fact]
        public void FrontOfFaceCanRotateClockwise()
        {
            var bottomFace = new ThreeByThreeCubeFace(Color.White);
            var topFace = new ThreeByThreeCubeFace(Color.White);
            var leftFace = new ThreeByThreeCubeFace(Color.White);
            var rightFace = new ThreeByThreeCubeFace(Color.White);
            var frontFace = new ThreeByThreeCubeFace(
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.White),
                    new Facelet(Color.Red),
                    new Facelet(Color.Orange)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Green),
                    new Facelet(Color.Blue),
                    new Facelet(Color.Yellow)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Blue),
                    new Facelet(Color.White),
                    new Facelet(Color.Red)
                }));

            MapFrontFace(frontFace.RotateClockwise, bottomFace, topFace, leftFace, rightFace);

            // Front of face rotated correctly.
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Blue), new Facelet(Color.Green), new Facelet(Color.White) }), frontFace.TopRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.White), new Facelet(Color.Blue), new Facelet(Color.Red) }), frontFace.MiddleRow, new CubeRowEqualityComparer());
            Assert.Equal(new CubeRow(new List<Facelet>() { new Facelet(Color.Red), new Facelet(Color.Yellow), new Facelet(Color.Orange) }), frontFace.BottomRow, new CubeRowEqualityComparer());
        }

        [Fact]
        public void ConnectedFaceRowsCanRoateClockwise()
        {
            var frontFace = new ThreeByThreeCubeFace(Color.White);

            var bottomFace = new ThreeByThreeCubeFace(
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Orange),
                    new Facelet(Color.White),
                    new Facelet(Color.Red)
                }),
                new CubeRow(Color.White, 3),
                new CubeRow(Color.White, 3));

            var topFace = new ThreeByThreeCubeFace(
                new CubeRow(Color.White, 3),
                new CubeRow(Color.White, 3),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Red),
                    new Facelet(Color.Yellow),
                    new Facelet(Color.Blue)
                }));

            var leftFace = new ThreeByThreeCubeFace(
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.White),
                    new Facelet(Color.White),
                    new Facelet(Color.Orange)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.White),
                    new Facelet(Color.White),
                    new Facelet(Color.Blue)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.White),
                    new Facelet(Color.White),
                    new Facelet(Color.Green)
                }));

            var rightFace = new ThreeByThreeCubeFace(
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Yellow),
                    new Facelet(Color.White),
                    new Facelet(Color.White)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Green),
                    new Facelet(Color.White),
                    new Facelet(Color.White)
                }),
                new CubeRow(new List<Facelet>()
                {
                    new Facelet(Color.Orange),
                    new Facelet(Color.White),
                    new Facelet(Color.White)
                }));

            var originalTop = topFace.BottomRow.DeepClone();
            var originalBottom = bottomFace.TopRow.DeepClone();
            var originalLeft = leftFace.RightRow.DeepClone();
            var originalRight = rightFace.LeftRow.DeepClone();

            var expectedRowOnTopFace = leftFace.RightRow.Reverse();
            var expectedRowOnBottomFace = rightFace.LeftRow.Reverse();

            MapFrontFace(frontFace.RotateClockwise, bottomFace, topFace, leftFace, rightFace);

            Assert.Equal(expectedRowOnTopFace, topFace.BottomRow, new CubeRowEqualityComparer());
            Assert.Equal(originalTop, rightFace.LeftRow, new CubeRowEqualityComparer());
            Assert.Equal(expectedRowOnBottomFace, bottomFace.TopRow, new CubeRowEqualityComparer());
            Assert.Equal(originalBottom, leftFace.RightRow, new CubeRowEqualityComparer());

            frontFace.RotateClockwise(topFace.BottomRow, bottomFace.TopRow, leftFace.RightRow, rightFace.LeftRow);
            frontFace.RotateClockwise(topFace.BottomRow, bottomFace.TopRow, leftFace.RightRow, rightFace.LeftRow);
            frontFace.RotateClockwise(topFace.BottomRow, bottomFace.TopRow, leftFace.RightRow, rightFace.LeftRow);

            Assert.Equal(originalTop, topFace.BottomRow, new CubeRowEqualityComparer());
            Assert.Equal(originalBottom, bottomFace.TopRow, new CubeRowEqualityComparer());
            Assert.Equal(originalLeft, leftFace.RightRow, new CubeRowEqualityComparer());
            Assert.Equal(originalRight, rightFace.LeftRow, new CubeRowEqualityComparer());
        }

        private void MapFrontFace(Action<CubeRow, CubeRow, CubeRow, CubeRow> rotate, ThreeByThreeCubeFace bottomFace, ThreeByThreeCubeFace topFace, ThreeByThreeCubeFace leftFace, ThreeByThreeCubeFace rightFace)
        {
            rotate(topFace.BottomRow, bottomFace.TopRow, leftFace.RightRow, rightFace.LeftRow);
        }
    }
}
