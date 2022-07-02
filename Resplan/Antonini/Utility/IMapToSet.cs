using System.Collections.Generic;

namespace Resplan.Antonini.Utility
{
    public interface IMapToSet<TX,TY>
    {
        bool Put(TX key, TY value);
        
        bool Remove(TX key, TY value);
        
        ISet<TY>? RemoveSet(TX key);
        
        ISet<TY>? Get(TX key);
        
        bool ContainsKey(TX key);
        
        bool IsEmpty();
        
        HashSet<KeyValuePair<TX, ISet<TY>>> EntrySet();
    }
}