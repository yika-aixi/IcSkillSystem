using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/PhysicsRaycaster Value")]
    public partial class PhysicsRaycasterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.PhysicsRaycaster _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.PhysicsRaycaster);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}