using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateBackFaceCounterClockwiseCommand : RotateFaceCounterClockwiseCommand
    {
        public RotateBackFaceCounterClockwiseCommand(Cube cube) : base(cube, cube.BackFace)
        {
        }
    }
}
