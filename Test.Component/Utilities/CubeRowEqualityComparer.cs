using RubiksSharp;
using System.Collections.Generic;

namespace Test.Component
{
    internal class CubeRowEqualityComparer : IEqualityComparer<CubeRow>
    {
        public bool Equals(CubeRow x, CubeRow y)
        {
            if (x.Facelets.Count != y.Facelets.Count)
            {
                return false;
            }

            for (var index = 0; index < x.Facelets.Count; index++)
            {
                if (x.Facelets[index].CurrentColor != y.Facelets[index].CurrentColor)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(CubeRow obj)
        {
            throw new System.NotImplementedException();
        }
    }
}