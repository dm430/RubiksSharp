using RubiksSharp.Model;
using RubiksSharp.Model.Data;
using System.Collections.Generic;
using System.Linq;

namespace RubiksSharp
{
    public class CubeRow : IDeepCloneable<CubeRow>
    {
        private readonly List<Facelet> facelets;

        public CubeRow(Color color, int rowSize)
        {
            facelets = new List<Facelet>();

            for (var index = 0; index < rowSize; index++)
            {
                facelets.Add(new Facelet(color));
            }
        }

        public CubeRow(List<Facelet> facelets)
        {
            this.facelets = facelets;
        }

        public IReadOnlyList<Facelet> Facelets => facelets;

        public bool IsSolved => Facelets.All(facelet => facelet.IsSolved);

        public object Clone()
        {
            var faceletClones = new List<Facelet>();

            for (var index = 0; index < facelets.Count; index++)
            {
                var faceletClone = facelets[index].DeepClone();

                faceletClones.Add(faceletClone);
            }

            return new CubeRow(faceletClones);
        }

        public CubeRow DeepClone()
        {
            return (CubeRow) Clone();
        }
    }
}