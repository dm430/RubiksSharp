using RubiksSharp.Model.Data;

namespace RubiksSharp.Model.Implementation
{
    public class ThreeByThreeCube : Cube
    {
        public ThreeByThreeCube() : base(
            front: new ThreeByThreeCubeFace(Color.Blue),
            back: new ThreeByThreeCubeFace(Color.Green),
            left: new ThreeByThreeCubeFace(Color.Red),
            right: new ThreeByThreeCubeFace(Color.Orange),
            top: new ThreeByThreeCubeFace(Color.White),
            bottom: new ThreeByThreeCubeFace(Color.Yellow))
        {
        }
    }
}
