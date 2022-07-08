using System.Collections.Generic;
using System.Linq;
using Optional.Collections;
using Optional.Unsafe;

namespace Resplan.Antonini.Utility
{
    /// <summary>
    /// A <see cref="Dictionary{TKey,TValue}"/> that maps Keys to set of values.
    /// </summary>
    /// <typeparam name="TX">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TY">The type of the values in the dictionary.</typeparam>
    public class HashMapToSet<TX,TY> : IMapToSet<TX,TY> where TX : notnull
    {

        private readonly Dictionary<TX, ISet<TY>> _map = new Dictionary<TX, ISet<TY>>();

        /// <summary>
        /// Insert the given value in the set mapped to the specified Key.
        /// <p>If the key is not already present a set containing the new value
        /// will be created and associated to the specified key.</p>
        /// </summary>
        /// <param name="key">The key with which the specified value is to be associated.</param>
        /// <param name="value"> The value to be associated with the specified key.</param>
        /// <returns>true if and only if the value was successfully mapped.</returns>
        public bool Put(TX key, TY value)
        {
            if (!_map.ContainsKey(key))
            {
                _map.Add(key, new HashSet<TY>());
            }
            return _map.GetValueOrNone(key).ValueOrFailure().Add(value);
        }

        /// <summary>
        /// Removes the specified value from the set mapped to the specified key if it is present.
        /// <p>If the value is the last element of the set associated to the specified
        /// key then removes the mapping for a key from this map.</p>
        /// </summary>
        /// <param name="key">The Key of the set where to search the value to remove.</param>
        /// <param name="value">The value to remove from the set associated to the specified Key.</param>
        /// <returns>true if and only if the value was successfully removed.</returns>
        public bool Remove(TX key, TY value) => _map.ContainsKey(key) && _map.GetValueOrNone(key).ValueOrFailure().Count.Equals(1) ? _map.Remove(key) : _map.GetValueOrNone(key).ValueOrFailure().Remove(value);

        /// <summary>
        /// Removes the mapping for a key from this map if is present.
        /// </summary>
        /// <param name="key">The key of the set to remove.</param>
        /// <returns>The removed set.</returns>
        public ISet<TY>? RemoveSet(TX key)
        {
            if (!_map.ContainsKey(key)) return null;
            var removed = _map.GetValueOrNone(key).ValueOrFailure();
            _map.Remove(key);
            return removed;
        }

        /// <summary>
        /// Get the set mapped to the given key if is present.
        /// </summary>
        /// <param name="key">The key of the set.</param>
        /// <returns>The set associated to the given Key if it is present , or
        /// null if there was no mapping for key.</returns>
        public ISet<TY>? Get(TX key) => _map.ContainsKey(key) ? _map.GetValueOrNone(key).ValueOrFailure() : null;

        /// <summary>
        ///Returns true if this map contains a mapping for the specified
        /// key, false otherwise.
        /// </summary>
        /// <param name="key">The key to check the mapping.</param>
        /// <returns>true if this map contains a mapping for the specified key.</returns>
        public bool ContainsKey(TX key) => _map.ContainsKey(key);

        /// <summary>
        /// Check if the map is empty.
        /// </summary>
        /// <returns>true if this map contains no key-set mappings.</returns>
        public bool IsEmpty() => _map.Count.Equals(0);

        /// <summary>
        /// Returns a <see cref="ISet{T}"/> view of the mappings contained in this map.
        /// </summary>
        /// <returns>a set view of the mappings contained in this map</returns>
        public HashSet<KeyValuePair<TX, ISet<TY>>> EntrySet() => _map.ToHashSet();
    }
}