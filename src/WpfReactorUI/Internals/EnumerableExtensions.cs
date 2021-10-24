using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.Internals
{
    public static class EnumerableExtensions
    {
        public static Dictionary<TKey, TElement> SafeToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey>? comparer = null) where TKey : notnull
        {
            var dictionary = new Dictionary<TKey, TElement>(comparer);

            if (source == null)
            {
                return dictionary;
            }

            foreach (TSource element in source)
            {
                dictionary[keySelector(element)] = elementSelector(element);
            }

            return dictionary;
        }

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));

        /// <summary>
        /// Gets the changes [Deleted, changed, inserted] comparing this collection to another.
        /// </summary>
        /// <param name="local">The source collection.</param>
        /// <param name="remote">The remote collection to comare agains.</param>
        /// <param name="keySelector">The primary key selector function</param>
        /// <param name="compareFunc">Optional camparing function between 2 objects of type TSource</param>
        /// <returns>List of changes as Added, Removed and Changed items of type TSource</returns>
        public static ChangeResult<T, T> CompareTo<T, TKey>(
            this IEnumerable<T> local, IEnumerable<T> remote, Func<T, TKey> keySelector, Func<T, T, bool>? compareFunc = null)
                where TKey : notnull
                where T : notnull
        {
            if (local == null)
                throw new ArgumentNullException(nameof(local));
            if (remote == null)
                throw new ArgumentNullException(nameof(remote));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            var remoteKeyValues = new ConcurrentDictionary<TKey, T>(remote.ToDictionary(keySelector));
            var localKeyValues = new ConcurrentDictionary<TKey, T>(local.ToDictionary(keySelector));
            var changed = new ConcurrentBag<(T Local, T Remote)>();

            foreach (var localItem in local)
            {
                var localItemKey = keySelector(localItem);

                //1. Check if item is both in local and remote
                if (remoteKeyValues.TryRemove(localItemKey, out var remoteItemValue))
                {
                    //1.a item is in both collections -> check if they are different
                    var isItemChanged = compareFunc != null ? !compareFunc(localItem, remoteItemValue) :
                         !localItem.Equals(remoteItemValue);

                    if (isItemChanged)
                    {
                        //1.b are different -> mark a change
                        changed.Add((Local: localItem, Remote: remoteItemValue));
                    }

                    //1.c remove the item from local list as it's prensent in remote list too
                    //this should never return false
                    localKeyValues.TryRemove(localItemKey, out var localItemValue);
                }

                //2. if item is not in remote list means it has been removed
            }

            var deleted = localKeyValues.Values;
            var inserted = remoteKeyValues.Values;

            return new ChangeResult<T, T>(deleted, changed, inserted);
        }

        /// <summary>
        /// Gets the changes [Deleted, changed, inserted] comparing this collection to another.
        /// </summary>
        /// <param name="local">The source collection.</param>
        /// <param name="remote">The remote collection to comare agains.</param>
        /// <param name="keySelector">The primary key selector function</param>
        /// <param name="compareFunc">Optional camparing function between 2 objects of type TSource</param>
        /// <returns>List of changes as Added, Removed and Changed items of type TSource</returns>
        public static ChangeResult<TLocal, TRemote> CompareTo<TLocal, TRemote, TKey>(
            this IEnumerable<TLocal> local, IEnumerable<TRemote> remote, Func<TLocal, TKey> keyLocalSelector, Func<TRemote, TKey> keyRemoteSelector, Func<TLocal, TRemote, bool>? compareFunc = null)
                where TKey : notnull
                where TLocal : notnull
        {
            if (local == null)
                throw new ArgumentNullException(nameof(local));
            if (remote == null)
                throw new ArgumentNullException(nameof(remote));
            if (keyLocalSelector == null)
                throw new ArgumentNullException(nameof(keyLocalSelector));
            if (keyRemoteSelector == null)
                throw new ArgumentNullException(nameof(keyRemoteSelector));

            var remoteKeyValues = new ConcurrentDictionary<TKey, TRemote>(remote.ToDictionary(keyRemoteSelector));
            var localKeyValues = new ConcurrentDictionary<TKey, TLocal>(local.ToDictionary(keyLocalSelector));
            var changed = new ConcurrentBag<(TLocal Local, TRemote Remote)>();

            foreach (var localItem in local)
            {
                var localItemKey = keyLocalSelector(localItem);

                //1. Check if item is both in local and remote
                if (remoteKeyValues.TryRemove(localItemKey, out var remoteItemValue))
                {
                    //1.a item is in both collections -> check if they are different
                    var isItemChanged = compareFunc != null ? !compareFunc(localItem, remoteItemValue) :
                         !localItem.Equals(remoteItemValue);

                    if (isItemChanged)
                    {
                        //1.b are different -> mark a change
                        changed.Add((Local: localItem, Remote: remoteItemValue));
                    }

                    //1.c remove the item from local list as it's prensent in remote list too
                    //this should never return false
                    localKeyValues.TryRemove(localItemKey, out var _);
                }

                //2. if item is not in remote list means it has been removed
            }

            var deleted = localKeyValues.Values;
            var inserted = remoteKeyValues.Values;

            return new ChangeResult<TLocal, TRemote>(deleted, changed, inserted);
        }
    }

    /// <summary>
    /// Immutable class containing changes
    /// </summary>
    public sealed class ChangeResult<TLocal, TRemote>
    {
        public ChangeResult(IEnumerable<TLocal> deleted, IEnumerable<(TLocal Local, TRemote Remote)> changed, IEnumerable<TRemote> inserted)
        {
            Deleted = deleted;
            Changed = changed;
            Inserted = inserted;
        }

        public IEnumerable<TLocal> Deleted { get; }

        public IEnumerable<(TLocal Local, TRemote Remote)> Changed { get; }

        public IEnumerable<TRemote> Inserted { get; }
    }
}
