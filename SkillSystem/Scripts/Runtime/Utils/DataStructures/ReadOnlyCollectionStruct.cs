//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年10月10日-00:27
//CabinIcarus.IcSkillSystem.Runtime

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    /// <summary>
    /// https://github.com/sebas77/Svelto.Common/blob/master/DataStructures/ReadOnlyCollectionStruct.cs
    /// </summary>
   public struct ReadOnlyCollectionStruct<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        public ReadOnlyCollectionStruct(T[] values, uint count)
        {
            _values = values;
            _count = count;
        }

        public ReadOnlyCollectionStructEnumerator<T> GetEnumerator()
        {
            return new ReadOnlyCollectionStructEnumerator<T>(_values, _count);
        }
        
        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _values[i];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count => (int) _count;

        public bool IsReadOnly => true;

        public bool IsSynchronized => false;

        public object SyncRoot => null;

        readonly T[] _values;
        readonly uint _count;
    }
    
    public struct ReadOnlyCollectionStructEnumerator<T>:IEnumerator<T>
    {
        public ReadOnlyCollectionStructEnumerator(T[] values, uint count) : this()
        {
            _index  = 0;
            _values = values;
            _count = count;
        }

        public bool MoveNext()
        {
            if (_index < _count)
            {
                _current = _values[_index++];
                return true;
            }

            return false;
        }
        
        bool IEnumerator.MoveNext()
        {
            return MoveNext();
        }
        
        void IEnumerator.Reset()
        {
            Reset();
        }

        public void Reset()
        {
            _index = 0;
        }
        
        public T Current => _current;

        T IEnumerator<T>.Current => _current;

        object IEnumerator.Current => _current;
        public void   Dispose() { }

        readonly T[] _values;
        T            _current;
        int          _index;
        readonly uint          _count;
    }
}