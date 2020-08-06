using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2Int Value")]
    public partial class Vector2IntValueNode:ValueNode<ValueInfo<UnityEngine.Vector2Int>>
    {
        [SerializeField]
        private UnityEngine.Vector2Int _value;
   
        private ValueInfo<UnityEngine.Vector2Int> _variableValue = new ValueInfo<UnityEngine.Vector2Int>();
   
        protected override ValueInfo<UnityEngine.Vector2Int> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}