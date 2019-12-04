using System;
using System.Collections.Generic;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    [Serializable]
    public class SerializationDict<TKey,TValue>:Dictionary<TKey,TValue>,ISerializationCallbackReceiver
    {
        #region Serialize

#if UNITY_EDITOR
        public const string KeysFieldName = nameof(_keys);
        public const string ValuesFieldName = nameof(_values);
#endif
        
        [SerializeField]
        List<TKey> _keys = new List<TKey>();
        
        [SerializeField]
        List<TValue> _values = new List<TValue>();

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();
            
            foreach (var keyValuePair in this)
            {
                _keys.Add(keyValuePair.Key);

                var value = keyValuePair.Value;

                _values.Add(value);
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();

            for (var i = 0; i < _keys.Count; i++)
            {
                var key = _keys[i];
                
                if (i >= _values.Count - 1)
                {
                    _values.Add(default);
                }
                
                var value = _values[i];
                
                Add(key,value);
            }
        }

        #endregion
    }
}