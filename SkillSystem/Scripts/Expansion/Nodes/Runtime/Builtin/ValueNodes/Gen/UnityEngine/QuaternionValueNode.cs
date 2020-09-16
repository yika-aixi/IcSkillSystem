using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Quaternion Value")]
    public partial class QuaternionValueNode:ValueNode<ValueInfo<UnityEngine.Quaternion>>
    {
        [SerializeField]
        private UnityEngine.Quaternion _value;
   
        private ValueInfo<UnityEngine.Quaternion> _variableValue;
   
        protected override ValueInfo<UnityEngine.Quaternion> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}