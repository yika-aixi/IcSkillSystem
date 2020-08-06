using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector3 Value")]
    public partial class Vector3ValueNode:ValueNode<ValueInfo<UnityEngine.Vector3>>
    {
        [SerializeField]
        private UnityEngine.Vector3 _value;
   
        private ValueInfo<UnityEngine.Vector3> _variableValue = new ValueInfo<UnityEngine.Vector3>();
   
        protected override ValueInfo<UnityEngine.Vector3> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}