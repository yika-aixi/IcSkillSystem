using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/MoveDirection Value")]
    public partial class MoveDirectionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.MoveDirection _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.MoveDirection);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}