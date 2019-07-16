using System.Collections.Generic;

namespace MilitaryElite.Interface
{
    public interface ILieutenantGeneral:IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
        void AddPrivate(ISoldier @private);
    }
}
