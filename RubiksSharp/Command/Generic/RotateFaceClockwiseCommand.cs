using RubiksSharp.Model;

namespace RubiksSharp.Command.Generic
{
    public class RotateFaceClockwiseCommand : IFaceRotationCommand
    {
        private readonly Cube cube;
        private readonly CubeFace face;

        public RotateFaceClockwiseCommand(Cube cube, CubeFace face)
        {
            this.cube = cube;
            this.face = face;
        }

        public void Execute()
        {
            cube.RotateClockwise(face);
        }

        public void Unexecute()
        {
            cube.RotateCounterClockwise(face);
        }
    }
}