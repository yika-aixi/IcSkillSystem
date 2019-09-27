using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Bounds Value")]
    public partial class BoundsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Bounds _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Bounds);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}