using System;

namespace RubiksSharp.Model
{
    interface IDeepCloneable<TType> : ICloneable
    {
        TType DeepClone();
    }
}
