using RubiksSharp.Model;
using RubiksSharp.Model.Data;

namespace RubiksSharp
{
    public class Facelet : IDeepCloneable<Facelet>
    {
        public Facelet(Color color)
        {
            IdentityColor = color;
            CurrentColor = color;
        }

        public Color IdentityColor { get; }

        public Color CurrentColor { get; set; }

        public bool IsSolved => CurrentColor == IdentityColor;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Facelet DeepClone()
        {
            return (Facelet) Clone();
        }
    }
}