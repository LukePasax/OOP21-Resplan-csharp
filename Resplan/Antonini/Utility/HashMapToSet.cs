using System.Collections.Generic;
using System.Linq;
using Optional.Collections;
using Optional.Unsafe;

namespace Resplan.Antonini.Utility
{
    public class HashMapToSet<TX,TY> : IMapToSet<TX,TY> where TX : notnull
    {

        private readonly Dictionary<TX, ISet<TY>> _map = new Dictionary<TX, ISet<TY>>();

        public bool Put(TX key, TY value)
        {
            if (!_map.ContainsKey(key))
            {
                _map.Add(key, new HashSet<TY>());
            }
            return _map.GetValueOrNone(key).ValueOrFailure().Add(value);
        }

        public bool Remove(TX key, TY value) => _map.ContainsKey(key) && _map.GetValueOrNone(key).ValueOrFailure().Count.Equals(1) ? _map.Remove(key) : _map.GetValueOrNone(key).ValueOrFailure().Remove(value);

        public ISet<TY>? RemoveSet(TX key)
        {
            if (!_map.ContainsKey(key)) return null;
            var removed = _map.GetValueOrNone(key).ValueOrFailure();
            _map.Remove(key);
            return removed;
        }

        public ISet<TY>? Get(TX key) => _map.ContainsKey(key) ? _map.GetValueOrNone(key).ValueOrFailure() : null;

        public bool ContainsKey(TX key) => _map.ContainsKey(key);

        public bool IsEmpty() => _map.Count.Equals(0);

        public HashSet<KeyValuePair<TX, ISet<TY>>> EntrySet() => _map.ToHashSet();
    }
}