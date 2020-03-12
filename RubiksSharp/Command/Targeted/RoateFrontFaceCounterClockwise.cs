using RubiksSharp.Command.Generic;
using RubiksSharp.Model;

namespace RubiksSharp.Command.Targeted
{
    public class RoateFrontFaceCounterClockwise : RotateFaceCounterClockwiseCommand
    {
        public RoateFrontFaceCounterClockwise(Cube cube) : base(cube, cube.FrontFace)
        {
        }
    }
}
