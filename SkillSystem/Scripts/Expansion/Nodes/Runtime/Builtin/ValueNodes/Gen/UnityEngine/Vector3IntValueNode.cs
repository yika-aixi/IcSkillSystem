using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector3Int Value")]
    public partial class Vector3IntValueNode:ValueNode<ValueInfo<UnityEngine.Vector3Int>>
    {
        [SerializeField]
        private UnityEngine.Vector3Int _value;
   
        private ValueInfo<UnityEngine.Vector3Int> _variableValue;
   
        protected override ValueInfo<UnityEngine.Vector3Int> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}