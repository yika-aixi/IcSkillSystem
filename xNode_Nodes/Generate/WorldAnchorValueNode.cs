using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/WorldAnchor Value")]
    public partial class WorldAnchorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.WorldAnchor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.WorldAnchor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}