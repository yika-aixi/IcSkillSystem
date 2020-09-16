using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    /// <summary>
    /// https://github.com/sebas77/Svelto.Common/blob/433b39f4a1b9a17301988ecd8a633d049bb4378d/DataStructures/FasterList.cs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct FasterListEnumerator<T> : IEnumerator<T>
    {
        public T Current => _current;

        public FasterListEnumerator(T[] buffer, int size)
        {
            _size = size;
            _counter = 0;
            _buffer = buffer;
            _current = default(T);
        }

        object IEnumerator.Current => _current;

        T IEnumerator<T>.Current => _current;

        public void Dispose()
        {
            _buffer = null;
        }

        public bool MoveNext()
        {
            if (_counter < _size)
            {
                _current = _buffer[_counter++];

                return true;
            }

            _current = default;

            return false;
        }

        public void Reset()
        {
            _counter = 0;
        }

        bool IEnumerator.MoveNext()
        {
            return MoveNext();
        }

        void IEnumerator.Reset()
        {
            Reset();
        }

        T[] _buffer;
        int _counter;
        readonly int _size;
        T _current;
    }

    public struct FasterListEnumeratorCast<T, U> : IEnumerator<T> where T:U
    {
        public T Current => (T)_buffer.Current;

        public FasterListEnumeratorCast(FasterListEnumerator<U> buffer)
        {
            _buffer = buffer;
        }

        object IEnumerator.Current => (T)_buffer.Current;

        T IEnumerator<T>.Current => (T)_buffer.Current;

        public void Dispose()
        {}

        public bool MoveNext()
        {
            return _buffer.MoveNext();
        }

        public void Reset()
        {
            _buffer.Reset();
        }

        bool IEnumerator.MoveNext()
        {
            return MoveNext();
        }

        void IEnumerator.Reset()
        {
            Reset();
        }

        FasterListEnumerator<U> _buffer;
    }

    public struct FasterReadOnlyList<T> : IList<T>
    {
        public static FasterReadOnlyList<T> DefaultList = new FasterReadOnlyList<T>(FasterList<T>.DefaultList);

        public int Count => _list.Count;
        public bool IsReadOnly => true;

        public FasterReadOnlyList(FasterList<T> list)
        {
            _list = list;
        }

        public T this[int index] { get => _list[index]; set => throw new NotImplementedException(); }

        public FasterListEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        readonly FasterList<T> _list;
    }

    public class FasterListThreadSafe<T> : IList<T>
    {
        public FasterListThreadSafe(FasterList<T> list)
        {
            if (list == null) throw new ArgumentException("invalid list");
            _list = list;
            _lockQ = new ReaderWriterLockSlim();
        }
        
        public FasterListThreadSafe()
        {
            _list  = new FasterList<T>();
            _lockQ = new ReaderWriterLockSlim();
        }

        public int Count
        {
            get
            {
                _lockQ.EnterReadLock();
                try
                {
                    return _list.Count;
                }
                finally
                {
                    _lockQ.ExitReadLock();
                }
            }
        }
        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                _lockQ.EnterReadLock();
                try
                {
                    return _list[index];
                }
                finally
                {
                    _lockQ.ExitReadLock();
                }
            }
            set
            {
                _lockQ.EnterWriteLock();
                try
                {
                    _list[index] = value;
                }
                finally
                {
                    _lockQ.ExitWriteLock();
                }
            }
        }

        public FasterListEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(T item)
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.Add(item);
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }

        public void Clear()
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.Clear();
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }

        public void FastClear()
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.FastClear();
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }

        public bool Contains(T item)
        {
            _lockQ.EnterReadLock();
            try
            {
                return _list.Contains(item);
            }
            finally
            {
                _lockQ.ExitReadLock();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _lockQ.EnterReadLock();
            try
            {
                _list.CopyTo(array, arrayIndex);
            }
            finally
            {
                _lockQ.ExitReadLock();
            }
        }

        public bool Remove(T item)
        {
            _lockQ.EnterWriteLock();
            try
            {
                return _list.Remove(item);
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }

        public int IndexOf(T item)
        {
            _lockQ.EnterReadLock();
            try
            {
                return _list.IndexOf(item);
            }
            finally
            {
                _lockQ.ExitReadLock();
            }
        }

        public void Insert(int index, T item)
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.Insert(index, item);
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }

        public void RemoveAt(int index)
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.RemoveAt(index);
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }

        public void UnorderedRemoveAt(int index)
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.UnorderedRemoveAt(index);
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }
        
        public void UnorderedRemove(T value)
        {
            _lockQ.EnterWriteLock();
            try
            {
                _list.UnorderedRemove(value);
            }
            finally
            {
                _lockQ.ExitWriteLock();
            }
        }
        
        public T[] ToArrayFast(out int count)
        {
            _lockQ.EnterReadLock();
            try
            {
                count = _list.Count;
                return _list.ToArrayFast();
            }
            finally
            {
                _lockQ.ExitReadLock();
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        readonly FasterList<T> _list;

        readonly ReaderWriterLockSlim _lockQ;
    }

    public struct FasterReadOnlyListCast<T, U> : IList<U> where U:T
    {
        public static readonly FasterReadOnlyListCast<T, U> DefaultList = new FasterReadOnlyListCast<T, U>(new FasterList<T>());

        public int Count => _list.Count;
        public bool IsReadOnly => true;

        public FasterReadOnlyListCast(FasterList<T> list)
        {
            _list = list;
        }

        public U this[int index] { get => (U)_list[index]; set => throw new NotImplementedException(); }

        public FasterListEnumeratorCast<U, T> GetEnumerator()
        {
            return new FasterListEnumeratorCast<U, T>(_list.GetEnumerator());
        }

        public void Add(U item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(U item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(U[] array, int arrayIndex)
        {
            Array.Copy(_list.ToArrayFast(), 0, array, arrayIndex, _list.Count);
        }

        public bool Remove(U item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(U item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, U item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator<U> IEnumerable<U>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        readonly FasterList<T> _list;
    }

    public class FasterList<T> : IList<T>
    {
        public static readonly FasterList<T> DefaultList = new FasterList<T>();

        const uint MIN_SIZE = 0;

        public int Count => (int) _count;

        public int ActualCount => _buffer.Length;
        
        public bool IsReadOnly => false;

        public FasterList()
        {
            _count = 0;

            _buffer = new T[MIN_SIZE];
        }

        public FasterList(uint initialSize = MIN_SIZE)
        {
            _count = 0;

            _buffer = new T[initialSize];
        }

        public FasterList(int initialSize)
        {
            _count = 0;

            _buffer = new T[initialSize];
        }

        public FasterList(T[] collection)
        {
            _buffer = new T[collection.Length];

            Array.Copy(collection, _buffer, collection.Length);

            _count = (uint) collection.Length;
        }

        public FasterList(ICollection<T> collection)
        {
            _buffer = new T[collection.Count];

            collection.CopyTo(_buffer, 0);

            _count = (uint) collection.Count;
        }

        public FasterList(ICollection<T> collection, int extraSize)
        {
            _buffer = new T[collection.Count + extraSize];

            collection.CopyTo(_buffer, 0);

            _count = (uint) collection.Count;
        }

        public FasterList(FasterList<T> listCopy)
        {
            _buffer = new T[listCopy.Count];

            listCopy.CopyTo(_buffer, 0);

            _count = (uint) listCopy.Count;
        }

        T IList<T>.this[int index]
        {
            get
            {
                IcCheck.True(index < _count && _count > 0, "out of bound index");
                return _buffer[index];
            }
            set 
            {
                IcCheck.True(index < _count && _count > 0, "out of bound index");
                _buffer[index] = value; 
            }
        }
        
        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                IcCheck.True(index < _count && _count > 0, "out of bound index");
                return ref _buffer[index];
            }
        }

        public ref T this[uint index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                IcCheck.True(index < _count, "out of bound index");
                return ref _buffer[index];
            }
        }

        public void Add(T item)
        {
            if (_count == _buffer.Length)
                AllocateMore();

            _buffer[_count++] = item;
        }
        
        public void AddIn(in T item)
        {
            if (_count == _buffer.Length)
                AllocateMore();

            _buffer[_count++] = item;
        }

        public void AddRef(ref T item)
        {
            if (_count == _buffer.Length)
                AllocateMore();

            _buffer[_count++] = item;
        }
        
        public void Add(uint location, T item)
        {
            Expand(location + 1);

            _buffer[location] = item;
        }

        /// <summary>
        /// this is a dirtish trick to be able to use the index operator
        /// before adding the elements through the Add functions
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="initialSize"></param>
        /// <returns></returns>
        public static FasterList<T> PreFill<U>(uint initialSize) where U: T, new()
        {
            var list = new FasterList<T>(initialSize);

            if (typeof(U).IsClass)
            {
                for (int i = 0; i < initialSize; i++)
                    list._buffer[(uint) (i)] = new U();
            }

            return list;
        }
        
        public static FasterList<T> Fill<U>(uint initialSize) where U: T, new()
        {
            var list = PreFill<U>(initialSize);

            list._count = initialSize;

            return list;
        }

        public void AddRange(IEnumerable<T> items, uint count)
        {
            AddRange(items.GetEnumerator(), count);
        }

        public void AddRange(IEnumerator<T> items, uint count)
        {
            if (_count + count > _buffer.Length)
                AllocateMore(_count + count);

            while (items.MoveNext())
                _buffer[_count++] = items.Current;
        }

        public void AddRange(ICollection<T> items)
        {
            AddRange(items.GetEnumerator(), (uint)items.Count);
        }

        public void AddRange(FasterList<T> items)
        {
            AddRange(items.ToArrayFast(), (uint)items.Count);
        }

        public void AddRange(T[] items, uint count)
        {
            if (count == 0) return;

            if (_count + count > _buffer.Length)
                AllocateMore(_count + count);

            Array.Copy(items, 0, _buffer, _count, count);
            _count += count;
        }

        public void AddRange(T[] items)
        {
            AddRange(items, (uint)items.Length);
        }

        public FasterReadOnlyList<T> AsReadOnly()
        {
            return new FasterReadOnlyList<T>(this);
        }

        /// <summary>
        /// Careful, you could keep on holding references you don't want to hold to anymore
        /// Use Clear in case.
        /// </summary>
        public void FastClear()
        {
#if DEBUG && !PROFILER
            if (typeof(T).IsClass)
                Debug.LogWarning(
                    "Warning: objects held by this list won't be garbage collected. Use ResetToReuse or Clear " +
                    "to avoid this warning");
#endif            
            _count = 0;
        }
        
        public void ResetToReuse()
        {
            _count = 0;
        }
        
        public bool ReuseOneSlot<U>(out U result) where U:class, T
        {
            result = null;

            if (_count >= _buffer.Length)
                return false;

            result = (U)_buffer[_count];

            if (result != null)
            {
                _count++;

                return true;
            }

            return false;
        }
        
        public bool ReuseOneSlot()
        {
            if (_count >= _buffer.Length)
                return false;
            
            _count++;

            return true;
        }

        public void Clear()
        {
            Array.Clear(_buffer, 0, _buffer.Length);

            _count = 0;
        }

        public bool Contains(T item)
        {
            var index = IndexOf(item);

            return index != -1;
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_buffer, 0, array, arrayIndex, Count);
        }

        public FasterListEnumerator<T> GetEnumerator()
        {
            return new FasterListEnumerator<T>(_buffer, Count);
        }

        public int IndexOf(T item)
        {
            var comp = EqualityComparer<T>.Default;

            for (var index = 0; index < _count; index++)
                if (comp.Equals(_buffer[index], item))
                    return index;

            return -1;
        }

        public void Insert(int index, T item)
        {
            IcCheck.True(index < _count, "out of bound index");

            if (_count == _buffer.Length) AllocateMore();

            Array.Copy(_buffer, index, _buffer, index + 1, _count - index);

            _buffer[index] = item;
            ++_count;
        }

        public void Release()
        {
            _count = 0;
            _buffer = null;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
                return false;

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            IcCheck.True(index < _count, "out of bound index");

            if (index == --_count)
                return;

            Array.Copy(_buffer, index + 1, _buffer, index, _count - index);

            _buffer[_count] = default(T);
        }

        public void Resize(uint newSize)
        {
            if (newSize == _buffer.Length) return;

            if (newSize < MIN_SIZE)
                newSize = MIN_SIZE;

            Array.Resize(ref _buffer, (int) newSize);
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_buffer, 0, (int)_count, comparer);
        }

        public void Sort()
        {
            Array.Sort(_buffer, 0, (int)_count, Comparer<T>.Default);
        }

        public T[] ToArray()
        {
            T[] destinationArray = new T[_count];

            Array.Copy(_buffer, 0, destinationArray, 0, _count);

            return destinationArray;
        }

        /// <summary>
        /// This function exists to allow fast iterations. The size of the array returned cannot be
        /// used. The list count must be used instead.
        /// </summary>
        /// <returns></returns>
        public T[] ToArrayFast()
        {
            return _buffer;
        }

        public bool UnorderedRemove(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
                return false;

            UnorderedRemoveAt(index);

            return true;
        }

        public bool UnorderedRemoveAt(int index)
        {
            IcCheck.True(index < _count && _count > 0, "out of bound index");

            if (index == --_count)
            {
                _buffer[_count] = default(T);
                return false;
            }

            _buffer[index] = _buffer[_count];
            _buffer[_count] = default(T);

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        void AllocateMore()
        {
            var newList = new T[(_buffer.Length + 1) << 1];
            if (_count > 0) _buffer.CopyTo(newList, 0);
            _buffer = newList;
        }

        void AllocateMore(uint newSize)
        {
            IcCheck.True(newSize > _buffer.Length);
            var newLength = Math.Max(_buffer.Length, 1);

            while (newLength < newSize)
                newLength <<= 1;

            var newList = new T[newLength];
            if (_count > 0) Array.Copy(_buffer, newList, _count);
            _buffer = newList;
        }

        public void Trim()
        {
            if (_count < _buffer.Length)
                Resize(_count);
        }

        public void TrimCount(uint newCount)
        {
            IcCheck.True(_count >= newCount, "the new length must be less than the current one");

            _count = newCount;
        }

        public void UnorderedRemoveRange(int groupStart, int groupEnd)
        {
            Array.Copy(_buffer, groupEnd, _buffer, groupStart, groupEnd - groupStart);
        }

        public void ExpandBy(uint increment)
        {
            uint count = _count + increment;
            
            if (_buffer.Length < count)
                AllocateMore(count);

            _count = count;
        }
        
        public void Expand(uint newSize)
        {
            if (_buffer.Length < newSize)
                AllocateMore(newSize);

            if (_count < newSize)
                _count = newSize;
        }

        T[] _buffer;
        uint _count;

        public static class NoVirt
        {
            public static uint Count(FasterList<T> fasterList)
            {
                return fasterList._count;
            }

            public static T[] ToArrayFast(FasterList<T> fasterList, out uint count)
            {
                count = fasterList._count;

                return fasterList._buffer;
            }

            internal static T[] ToArrayFast(FasterList<T> fasterList)
            {
                return fasterList._buffer;
            }

            public static void FastSet(FasterList<T> fasterList, uint index, T item)
            {
                fasterList._buffer[index] = item;
                fasterList._count = index + 1;
            }
        }
    }
}