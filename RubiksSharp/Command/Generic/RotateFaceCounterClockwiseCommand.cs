using RubiksSharp.Model;

namespace RubiksSharp.Command.Generic
{
    public class RotateFaceCounterClockwiseCommand : IFaceRotationCommand
    {
        private readonly Cube cube;
        private readonly CubeFace face;

        public RotateFaceCounterClockwiseCommand(Cube cube, CubeFace face)
        {
            this.cube = cube;
            this.face = face;
        }

        public void Execute()
        {
            cube.RotateCounterClockwise(face);
        }

        public void Unexecute()
        {
            cube.RotateClockwise(face);
        }
    }
}