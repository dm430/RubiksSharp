using RubiksSharp.Model;
using System.Linq;

namespace Test.Component.Utilities
{
    public static class CubeRowUtilities
    {
        public static CubeRow Reverse(this CubeRow row)
        {
            var clonedRow = row.DeepClone();
            var reversedFacelets = clonedRow.Facelets.Reverse();

            return new CubeRow(reversedFacelets.ToList());
        }
    }
}
