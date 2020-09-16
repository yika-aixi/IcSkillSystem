using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LayerMask Value")]
    public partial class LayerMaskValueNode:ValueNode<ValueInfo<UnityEngine.LayerMask>>
    {
        [SerializeField]
        private UnityEngine.LayerMask _value;
   
        private ValueInfo<UnityEngine.LayerMask> _variableValue;
   
        protected override ValueInfo<UnityEngine.LayerMask> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}