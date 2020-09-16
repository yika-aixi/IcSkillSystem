using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/BoxcastCommand Value")]
    public partial class BoxcastCommandValueNode:ValueNode<ValueInfo<UnityEngine.BoxcastCommand>>
    {
        [SerializeField]
        private UnityEngine.BoxcastCommand _value;
   
        private ValueInfo<UnityEngine.BoxcastCommand> _variableValue;
   
        protected override ValueInfo<UnityEngine.BoxcastCommand> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}