using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RotateBottomFaceClockwiseCommand : RotateFaceClockwiseCommand
    {
        public RotateBottomFaceClockwiseCommand(Cube cube) : base(cube, cube.BottomFace)
        {
        }
    }
}
