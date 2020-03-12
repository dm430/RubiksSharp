using Moq;
using RubiksSharp.Command.Generic;
using RubiksSharp.Model;
using RubiksSharp.Model.Data;
using Xunit;

namespace Test.Component.Command
{
    public class RotateFaceClockwiseCommandtests
    {
        private readonly Mock<Cube> cubeMock;
        private readonly RotateFaceClockwiseCommand rotateFaceClockwiseCommand;

        public RotateFaceClockwiseCommandtests()
        {
            var mockFace = new Mock<CubeFace>(Color.White, 1, 1);

            cubeMock = new Mock<Cube>(mockFace.Object, mockFace.Object, mockFace.Object, mockFace.Object, mockFace.Object, mockFace.Object);
            rotateFaceClockwiseCommand = new RotateFaceClockwiseCommand(cubeMock.Object, cubeMock.Object.FrontFace);
        }

        [Fact]
        public void CanExecuteClockwiseRotation()
        {
            rotateFaceClockwiseCommand.Execute();
            cubeMock.Verify(call => call.RotateClockwise(cubeMock.Object.FrontFace));
        }

        [Fact]
        public void CanUnexecuteClockwiseRotation()
        {
            rotateFaceClockwiseCommand.Unexecute();
            cubeMock.Verify(call => call.RotateCounterClockwise(cubeMock.Object.FrontFace));
        }
    }
}
