using RubiksSharp;
using RubiksSharp.Model.Data;
using RubiksSharp.Model.Implementation;
using System.Collections.Generic;
using System.Linq;
using Test.Component.Utilities;
using Xunit;

namespace Test.Component
{
    public class FaceTests
    {
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

            frontFace.RotateClockwise(topFace.BottomRow, bottomFace.TopRow, leftFace.RightRow, rightFace.LeftRow);

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
    }
}
