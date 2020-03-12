using System;
using System.Collections.Generic;
using Moq;
using RubiksSharp.Command.Generic;
using RubiksSharp.Command.Targeted;
using RubiksSharp.Model;
using RubiksSharp.Model.Data;
using Xunit;

namespace Test.Component.Command
{
    public class TargetedFaceRotationCommandTests
    {
        [Theory]
        [MemberData(nameof(GetClockwiseCommands))]
        public void CanClockwiseExecute(RotateFaceClockwiseCommand rotateFaceClockwiseCommand, CubeFace targetFace, Mock<Cube> cubeMock)
        {
            rotateFaceClockwiseCommand.Execute();
            cubeMock.Verify(call => call.RotateClockwise(targetFace));
        }

        [Theory]
        [MemberData(nameof(GetClockwiseCommands))]
        public void CanClockwiseUnexecute(RotateFaceClockwiseCommand rotateFaceClockwiseCommand, CubeFace targetFace, Mock<Cube> cubeMock)
        {
            rotateFaceClockwiseCommand.Unexecute();
            cubeMock.Verify(call => call.RotateCounterClockwise(targetFace));
        }

        [Theory]
        [MemberData(nameof(GetCounterClockwiseCommands))]
        public void CanCounterClockwiseExecute(RotateFaceCounterClockwiseCommand rotateFaceClockwiseCommand, CubeFace targetFace, Mock<Cube> cubeMock)
        {
            rotateFaceClockwiseCommand.Execute();
            cubeMock.Verify(call => call.RotateCounterClockwise(targetFace));
        }

        [Theory]
        [MemberData(nameof(GetCounterClockwiseCommands))]
        public void CanCounterClockwiseUnexecute(RotateFaceCounterClockwiseCommand rotateFaceClockwiseCommand, CubeFace targetFace, Mock<Cube> cubeMock)
        {
            rotateFaceClockwiseCommand.Unexecute();
            cubeMock.Verify(call => call.RotateClockwise(targetFace));
        }

        public static IEnumerable<object[]> GetClockwiseCommands()
        {
            var right = MockCube("right");
            var left = MockCube("left");
            var top = MockCube("top");
            var bottom = MockCube("bottom");
            var front = MockCube("front");
            var back = MockCube("back");

            var allData = new List<object[]>
            {
                new object[] { new RotateRightFaceClockwiseCommand(right.Object), right.Object.RightFace, right },
                new object[] { new RotateLeftFaceClockwiseCommand(left.Object), left.Object.LeftFace, left },
                new object[] { new RotateTopFaceClockwiseCommand(top.Object), top.Object.TopFace, top },
                new object[] { new RotateBottomFaceClockwiseCommand(bottom.Object), bottom.Object.BottomFace, bottom },
                new object[] { new RotateFrontFaceClockwiseCommand(front.Object), front.Object.FrontFace, front },
                new object[] { new RotateBackFaceClockwiseCommand(back.Object), back.Object.BackFace, back },
            };

            return allData;
        }

        public static IEnumerable<object[]> GetCounterClockwiseCommands()
        {
            var right = MockCube("right");
            var left = MockCube("left");
            var top = MockCube("top");
            var bottom = MockCube("bottom");
            var front = MockCube("front");
            var back = MockCube("back");

            var allData = new List<object[]>
            {
                new object[] { new RotateRightFaceCounterClockwiseCommand(right.Object), right.Object.RightFace, right },
                new object[] { new RotateLeftFaceCounterClockwiseCommand(left.Object), left.Object.LeftFace, left },
                new object[] { new RotateTopFaceCounterClockwiseCommand(top.Object), top.Object.TopFace, top },
                new object[] { new RotateBottomFaceCounterClockwiseCommand(bottom.Object), bottom.Object.BottomFace, bottom },
                new object[] { new RotateFrontFaceCounterClockwiseCommand(front.Object), front.Object.FrontFace, front },
                new object[] { new RotateBackFaceCounterClockwiseCommand(back.Object), back.Object.BackFace, back },
            };

            return allData;
        }

        private static Mock<Cube> MockCube(string targetFace)
        {
            var targetFaceMock = new Mock<CubeFace>(Color.White, 1, 1);
            var otherFacesMock = new Mock<CubeFace>(Color.Red, 1, 1);
            var cubeMock = new Mock<Cube>(targetFaceMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object);

            if (targetFace == "left")
            {
                cubeMock = new Mock<Cube>(otherFacesMock.Object, otherFacesMock.Object, targetFaceMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object);
            }
            else if (targetFace == "right")
            {
                cubeMock = new Mock<Cube>(otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, targetFaceMock.Object, otherFacesMock.Object, otherFacesMock.Object);
            }
            else if (targetFace == "top")
            {
                cubeMock = new Mock<Cube>(otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, targetFaceMock.Object, otherFacesMock.Object);
            }
            else if (targetFace == "bottom")
            {
                cubeMock = new Mock<Cube>(otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, targetFaceMock.Object);
            }
            else if (targetFace == "back")
            {
                cubeMock = new Mock<Cube>(otherFacesMock.Object, targetFaceMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object, otherFacesMock.Object);
            }

            return cubeMock;
        }
    }
}
