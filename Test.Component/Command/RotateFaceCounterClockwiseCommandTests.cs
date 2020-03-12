using Moq;
using RubiksSharp.Command.Generic;
using RubiksSharp.Model;
using RubiksSharp.Model.Data;
using Xunit;

namespace Test.Component.Command
{
    public class RotateFaceCounterClockwiseCommandTests
    {
        private readonly Mock<Cube> cubeMock;
        private readonly RotateFaceCounterClockwiseCommand rotateFaceCounterClockwiseCommand;

        public RotateFaceCounterClockwiseCommandTests()
        {
            var mockFace = new Mock<CubeFace>(Color.White, 1, 1);

            cubeMock = new Mock<Cube>(mockFace.Object, mockFace.Object, mockFace.Object, mockFace.Object, mockFace.Object, mockFace.Object);
            rotateFaceCounterClockwiseCommand = new RotateFaceCounterClockwiseCommand(cubeMock.Object, cubeMock.Object.FrontFace);
        }

        [Fact]
        public void CanExecuteCounterClockwiseRotation()
        {
            rotateFaceCounterClockwiseCommand.Execute();
            cubeMock.Verify(call => call.RotateCounterClockwise(cubeMock.Object.FrontFace));
        }

        [Fact]
        public void CanUnexecuteCounterClockwiseRotation()
        {
            rotateFaceCounterClockwiseCommand.Unexecute();
            cubeMock.Verify(call => call.RotateClockwise(cubeMock.Object.FrontFace));
        }
    }
}
