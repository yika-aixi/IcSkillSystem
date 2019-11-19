//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年10月10日-00:23
//CabinIcarus.IcSkillSystem.Runtime

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    /// <summary>
    /// https://github.com/sebas77/Svelto.Common/blob/433b39f4a1b9a17301988ecd8a633d049bb4378d/DataStructures/FasterDictionary.cs
    ///
    ///
    /// 
    /// This dictionary has been created for just one reason: I needed a dictionary that would have let me iterate
    /// over the values as an array, directly, without generating one or using an iterator.
    /// For this goal is N times faster than the standard dictionary. Faster dictionary is also faster than
    /// the standard dictionary for most of the operations, but the difference is negligible. The only slower operation
    /// is resizing the memory on add, as this implementation needs to use two separate arrays compared to the standard
    /// one
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class FasterDictionary<TKey, TValue> : IDictionary<TKey, TValue> where TKey : IEquatable<TKey>
    {
        public FasterDictionary(uint size)
        {
            _valuesInfo = new Node[size];
            _values     = new TValue[size];
            _buckets    = new int[HashHelpers.GetPrime((int) size)];
        }

        public FasterDictionary() : this(1) { }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => throw new NotImplementedException();

        public FasterDictionaryKeys Keys => throw new NotImplementedException();

        ICollection<TValue> IDictionary<TKey, TValue>.Values => throw new NotImplementedException();

        public ReadOnlyCollectionStruct<TValue> Values => new ReadOnlyCollectionStruct<TValue>(_values, _freeValueCellIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue[] GetValuesArray(out uint count)
        {
            count = (uint) _freeValueCellIndex;

            return _values;
        }

        public uint Collisions => _collisions;

        public int Count => (int) _freeValueCellIndex;

        public bool IsReadOnly => false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(TKey key, TValue value) { Add(key, ref value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Add(TKey key, ref TValue value)
        {
            if (AddValue(key, ref value) == false)
                throw new FasterDictionaryException("Key already present");

            return _freeValueCellIndex - 1;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint Set(TKey key, ref TValue value)
        {
            AddValue(key, ref value);

            return _freeValueCellIndex - 1;
        }

        public void Add(KeyValuePair<TKey, TValue> item) { throw new NotImplementedException(); }

        public void Clear()
        {
            if (_freeValueCellIndex == 0) return;

            _freeValueCellIndex = 0;

            Array.Clear(_buckets, 0, _buckets.Length);
            Array.Clear(_values, 0, _values.Length);
            Array.Clear(_valuesInfo, 0, _valuesInfo.Length);
        }

        public void FastClear()
        {
            if (_freeValueCellIndex == 0) return;

            _freeValueCellIndex = 0;

            Array.Clear(_buckets, 0, _buckets.Length);
            Array.Clear(_valuesInfo, 0, _valuesInfo.Length);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) { throw new NotImplementedException(); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(TKey key)
        {
            if (TryFindIndex(key, _buckets, _valuesInfo, out _))
            {
                return true;
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { throw new NotImplementedException(); }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            throw new Exception();
        }

        public FasterDictionaryKeyValueEnumerator GetEnumerator()
        {
            return new FasterDictionaryKeyValueEnumerator(this);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) { throw new NotImplementedException(); }

        public bool TryGetValue(TKey key, out TValue result)
        {
            if (TryFindIndex(key, _buckets, _valuesInfo, out var findIndex))
            {
                result = _values[findIndex];
                return true;
            }

            result = default;
            return false;
        }
        
        public ref TValue GetValueByRef(TKey key)
        {
            if (TryFindIndex(key, _buckets, _valuesInfo, out var findIndex))
            {
                return ref _values[findIndex];
            }

            throw new FasterDictionaryException("Key not found");
        }

        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }

        public void SetCapacity(uint size)
        {
            var expandPrime = HashHelpers.ExpandPrime((int) size);

            if (_values.Length < expandPrime)
            {
                Array.Resize(ref _values, expandPrime);
                Array.Resize(ref _valuesInfo, expandPrime);
            }
        }

        public TValue this[TKey key]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _values[GetIndex(key, _buckets, _valuesInfo)];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => AddValue(key, ref value);
        }
        
        bool AddValue(TKey key, ref TValue value)
        {
            if (_freeValueCellIndex == _values.Length)
            {
                var expandPrime = HashHelpers.ExpandPrime((int) _freeValueCellIndex);
                
                Array.Resize(ref _values, expandPrime);
                Array.Resize(ref _valuesInfo, expandPrime);
            }
            
            int  hash        = key.GetHashCode();
            uint bucketIndex = Reduce((uint) hash, (uint) _buckets.Length);

            //buckets value -1 means it's empty
            var valueIndex = _buckets[bucketIndex] - 1;

            if (valueIndex == -1)
                //create the info node at the last position and fill it with the relevant information
                _valuesInfo[_freeValueCellIndex] = new Node(ref key, hash);
            else //collision or already exists
            {
                {
                    int currentValueIndex = valueIndex;
                    do
                    {
                        //must check if the key already exists in the dictionary
                        //for some reason this is faster than using Comparer<TKey>.default, should investigate
                        if (_valuesInfo[currentValueIndex].hashcode == hash &&
                            _valuesInfo[currentValueIndex].key.Equals(key) == true)
                        {
                            //the key already exists, simply replace the value!
                            _values[currentValueIndex] = value;
                            return false;
                        }

                        currentValueIndex = _valuesInfo[currentValueIndex].previous;
                    }
                    while (currentValueIndex != -1); //-1 means no more values with key with the same hash
                }

                //oops collision!
                _collisions++;
                //create a new node which previous index points to node currently pointed in the bucket
                _valuesInfo[_freeValueCellIndex] = new Node(ref key, hash, valueIndex);
                //update the next of the existing cell to point to the new one
                //old one -> new one | old one <- next one
                _valuesInfo[valueIndex].next = (int) _freeValueCellIndex;
                //Important: the new node is always the one that will be pointed by the bucket cell
                //so I can assume that the one pointed by the bucket is always the last value added
                //(next = -1)
            }

            //item with this bucketIndex will point to the last value created
            //ToDo: if instead I assume that the original one is the one in the bucket
            //I wouldn't need to update the bucket here. Small optimization but important
            _buckets[bucketIndex] = (int) (_freeValueCellIndex + 1);

            _values[_freeValueCellIndex] = value;

            _freeValueCellIndex++;

            //too many collisions?
            if (_collisions > _buckets.Length)
            {
                //we need more space and less collisions
                _buckets = new int[HashHelpers.ExpandPrime((int) _collisions)];

                _collisions = 0;

                //we need to get all the hash code of all the values stored so far and spread them over the new bucket
                //length
                for (int newValueIndex = 0; newValueIndex < _freeValueCellIndex; newValueIndex++)
                {
                    //get the original hash code and find the new bucketIndex due to the new length
                    bucketIndex = Reduce((uint) _valuesInfo[newValueIndex].hashcode, (uint) _buckets.Length);
                    //bucketsIndex can be -1 or a next value. If it's -1 means no collisions. If there is collision,
                    //we create a new node which prev points to the old one. Old one next points to the new one.
                    //the bucket will now points to the new one
                    //In this way we can rebuild the linkedlist.
                    //get the current valueIndex, it's -1 if no collision happens
                    int existingValueIndex = _buckets[bucketIndex] - 1;
                    //update the bucket index to the index of the current item that share the bucketIndex
                    //(last found is always the one in the bucket)
                    _buckets[bucketIndex] = newValueIndex + 1;
                    if (existingValueIndex != -1)
                    {
                        //oops a value was already being pointed by this cell in the new bucket list,
                        //it means there is a collision, problem
                        _collisions++;
                        //the bucket will point to this value, so 
                        //the previous index will be used as previous for the new value.
                        _valuesInfo[newValueIndex].previous = existingValueIndex;
                        _valuesInfo[newValueIndex].next     = -1;
                        //and update the previous next index to the new one
                        _valuesInfo[existingValueIndex].next = newValueIndex;
                    }
                    else
                    {
                        //ok nothing was indexed, the bucket was empty. We need to update the previous
                        //values of next and previous
                        _valuesInfo[newValueIndex].next     = -1;
                        _valuesInfo[newValueIndex].previous = -1;
                    }
                }
            }

            return true;
        }

        public bool Remove(TKey key)
        {
            int  hash        = Hash(key);
            uint bucketIndex = Reduce((uint) hash, (uint) _buckets.Length);

            //find the bucket
            int indexToValueToRemove = _buckets[bucketIndex] - 1;

            //Part one: look for the actual key in the bucket list if found I update the bucket list so that it doesn't
            //point anymore to the cell to remove
            while (indexToValueToRemove != -1)
            {
                if (_valuesInfo[indexToValueToRemove].hashcode == hash &&
                    _valuesInfo[indexToValueToRemove].key.Equals(key) == true)
                {
                    //if the key is found and the bucket points directly to the node to remove
                    if (_buckets[bucketIndex] - 1 == indexToValueToRemove)
                    {
                        IcCheck.True(_valuesInfo[indexToValueToRemove].next == -1,
                                                 "if the bucket points to the cell, next MUST NOT exists");
                        //the bucket will point to the previous cell. if a previous cell exists
                        //its next pointer must be updated!
                        //<--- iteration order  
                        //                      B(ucket points always to the last one)
                        //   ------- ------- -------
                        //   |  1  | |  2  | |  3  | //bucket cannot have next, only previous
                        //   ------- ------- -------
                        //--> insert order
                        int value = _valuesInfo[indexToValueToRemove].previous;
                        _buckets[bucketIndex] = value + 1;
                    }
                    else
                        IcCheck.True(_valuesInfo[indexToValueToRemove].next != -1,
                                                 "if the bucket points to another cell, next MUST exists");

                    UpdateLinkedList(indexToValueToRemove, _valuesInfo);

                    break;
                }

                indexToValueToRemove = _valuesInfo[indexToValueToRemove].previous;
            }

            if (indexToValueToRemove == -1)
                return false; //not found!

            _freeValueCellIndex--; //one less value to iterate

            //Part two:
            //At this point nodes pointers and buckets are updated, but the _values array
            //still has got the value to delete. Remember the goal of this dictionary is to be able
            //to iterate over the values like an array, so the values array must always be up to date

            //if the cell to remove is the last one in the list, we can perform less operations (no swapping needed)
            //otherwise we want to move the last value cell over the value to remove
            if (indexToValueToRemove != _freeValueCellIndex)
            {
                //we can move the last value of both arrays in place of the one to delete.
                //in order to do so, we need to be sure that the bucket pointer is updated
                //first we find the index in the bucket list of the pointer that points to the cell
                //to move
                var movingBucketIndex = Reduce((uint) _valuesInfo[_freeValueCellIndex].hashcode, (uint) _buckets.Length);

                //if the key is found and the bucket points directly to the node to remove
                //it must now point to the cell where it's going to be moved
                if (_buckets[movingBucketIndex] - 1 == _freeValueCellIndex)
                    _buckets[movingBucketIndex] = (int) (indexToValueToRemove + 1);

                //otherwise it means that there was more than one key with the same hash (collision), so 
                //we need to update the linked list and its pointers
                int next     = _valuesInfo[_freeValueCellIndex].next;
                int previous = _valuesInfo[_freeValueCellIndex].previous;

                //they now point to the cell where the last value is moved into
                if (next != -1)
                    _valuesInfo[next].previous = (int) indexToValueToRemove;
                if (previous != -1)
                    _valuesInfo[previous].next = (int) indexToValueToRemove;

                //finally, actually move the values
                _valuesInfo[indexToValueToRemove] = _valuesInfo[_freeValueCellIndex];
                _values[indexToValueToRemove]     = _values[_freeValueCellIndex];
            }

            return true;
        }

        public void Trim()
        {
            var expandPrime = HashHelpers.ExpandPrime((int) _freeValueCellIndex);
            
            if (expandPrime < _valuesInfo.Length)
            {
                Array.Resize(ref _values, (int) expandPrime);
                Array.Resize(ref _valuesInfo, (int) expandPrime);
            }
        }

        //I store all the index with an offset + 1, so that in the bucket list 0 means actually not existing.
        //When read the offset must be offset by -1 again to be the real one. In this way
        //I avoid to initialize the array to -1
        public bool TryFindIndex(TKey key, out uint findIndex)
        {
            int  hash        = Hash(key);
            uint bucketIndex = Reduce((uint) hash, (uint) _buckets.Length);

            int valueIndex = _buckets[bucketIndex] - 1;

            //even if we found an existing value we need to be sure it's the one we requested
            while (valueIndex != -1)
            {
                //for some reason this is way faster than using Comparer<TKey>.default, should investigate
                if (_valuesInfo[valueIndex].hashcode == hash && _valuesInfo[valueIndex].key.Equals(key) == true)
                {
                    //this is the one
                    findIndex = (uint) valueIndex;
                    return true;
                }

                valueIndex = _valuesInfo[valueIndex].previous;
            }

            findIndex = 0;
            return false;
        }

        public ref TValue GetDirectValue(uint index)
        {
            return ref _values[index];
        }
        
        protected uint GetValueIndex(TKey index) { return GetIndex(index, _buckets, _valuesInfo); }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static int Hash(TKey key) { return key.GetHashCode(); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static uint Reduce(uint x, uint N)
        {
            if (x >= N)
                return x % N;

            return x;
        }

        static uint GetIndex(TKey key, int[] buckets, Node[] valuesInfo)
        {
            if (TryFindIndex(key, buckets, valuesInfo, out var findIndex)) return findIndex;

            throw new FasterDictionaryException("Key not found");
        }

        static bool TryFindIndex(TKey key, int[] buckets, Node[] valuesInfo, out uint findIndex)
        {
            int hash        = Hash(key);
            var bucketIndex = Reduce((uint) hash, (uint) buckets.Length);

            int valueIndex = buckets[bucketIndex] - 1;

            while (valueIndex != -1)
            {
                //for some reason this is way faster they use Comparer<TKey>.default, should investigate
                if (valuesInfo[valueIndex].hashcode == hash && valuesInfo[valueIndex].key.Equals(key) == true)
                {
                    findIndex = (uint) valueIndex;
                    return true;
                }

                valueIndex = valuesInfo[valueIndex].previous;
            }

            findIndex = 0;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void UpdateLinkedList(int index, Node[] valuesInfo)
        {
            int next     = valuesInfo[index].next;
            int previous = valuesInfo[index].previous;

            if (next != -1)
                valuesInfo[next].previous = previous;
            if (previous != -1)
                valuesInfo[previous].next = next;
        }

        public struct FasterDictionaryKeyValueEnumerator : IEnumerator<KeyValuePairFast<TKey, TValue>>
        {
            public FasterDictionaryKeyValueEnumerator(FasterDictionary<TKey, TValue> dic) : this()
            {
                _dic   = dic;
                _index = -1;
                _count = dic.Count;
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (_count != _dic.Count)
                    throw new FasterDictionaryException("can't modify a dictionary during its iteration");

                if (_index < _count - 1)
                {
                    _index++;
                    return true;
                }

                return false;
            }

            public void Reset() { throw new NotImplementedException(); }

            public KeyValuePairFast<TKey, TValue> Current => new KeyValuePairFast<TKey, TValue>(_dic._valuesInfo[_index].key, _dic._values, _index);

            object IEnumerator.Current => throw new NotImplementedException();

            readonly FasterDictionary<TKey, TValue> _dic;
            readonly int                            _count;

            int _index;
        }

        struct Node
        {
            public readonly TKey key;
            public readonly int  hashcode;
            public          int  previous;
            public          int  next;

            public Node(ref TKey key, int hash, int previousNode)
            {
                this.key = key;
                hashcode = hash;
                previous = previousNode;
                next     = -1;
            }

            public Node(ref TKey key, int hash)
            {
                this.key = key;
                hashcode = hash;
                previous = -1;
                next     = -1;
            }
        }

        public struct FasterDictionaryKeys : ICollection<TKey>
        {
            internal FasterDictionaryKeys(FasterDictionary<TKey, TValue> dic) : this() { }

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() { throw new NotImplementedException(); }

            IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }

            public FasterDictionaryKeyEnumerator GetEnumerator() { throw new NotImplementedException(); }

            public void Add(TKey item) { throw new NotImplementedException(); }

            public void Clear() { throw new NotImplementedException(); }

            public bool Contains(TKey item) { throw new NotImplementedException(); }

            public void CopyTo(TKey[] array, int arrayIndex) { throw new NotImplementedException(); }

            public bool Remove(TKey item) { throw new NotImplementedException(); }

            public int  Count      { get; }
            public bool IsReadOnly { get; }
        }

        public struct FasterDictionaryKeyEnumerator : IEnumerator<TKey>
        {
            public bool MoveNext() { throw new NotImplementedException(); }

            public void Reset() { throw new NotImplementedException(); }

            public TKey Current { get; }

            object IEnumerator.Current => Current;

            public void Dispose() { throw new NotImplementedException(); }
        }

        protected TValue[] _values;

        Node[]  _valuesInfo;
        int[]   _buckets;
        uint    _freeValueCellIndex;
        uint     _collisions;
    }

    public struct KeyValuePairFast<TKey, TValue>
    {
        readonly TValue[] _dicValues;
        readonly int _index;

        public KeyValuePairFast(TKey key, TValue[] dicValues, int index) { Key = key;
            _dicValues = dicValues;
            _index = index;
        }

        public readonly TKey Key;
        public ref TValue Value => ref _dicValues[_index];
    }

    public class FasterDictionaryException : Exception
    {
        public FasterDictionaryException(string keyAlreadyExisting) : base(keyAlreadyExisting) { }
    }
}