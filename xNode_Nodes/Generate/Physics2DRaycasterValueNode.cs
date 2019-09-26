using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Physics2DRaycaster Value")]
    public partial class Physics2DRaycasterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.Physics2DRaycaster _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.Physics2DRaycaster);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}