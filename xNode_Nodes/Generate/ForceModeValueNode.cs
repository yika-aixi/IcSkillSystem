using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ForceMode Value")]
    public partial class ForceModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ForceMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ForceMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}