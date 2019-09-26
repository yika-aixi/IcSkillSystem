using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/BaseInput Value")]
    public partial class BaseInputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.BaseInput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.BaseInput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}