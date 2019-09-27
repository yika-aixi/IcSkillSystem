using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/RaycastResult Value")]
    public partial class RaycastResultValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.RaycastResult _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.RaycastResult);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}