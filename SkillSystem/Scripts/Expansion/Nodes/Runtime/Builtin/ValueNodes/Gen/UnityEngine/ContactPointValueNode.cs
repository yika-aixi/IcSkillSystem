using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ContactPoint Value")]
    public partial class ContactPointValueNode:ValueNode<ValueInfo<UnityEngine.ContactPoint>>
    {
        [SerializeField]
        private UnityEngine.ContactPoint _value;
   
        private ValueInfo<UnityEngine.ContactPoint> _variableValue;
   
        protected override ValueInfo<UnityEngine.ContactPoint> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}