using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/SurfaceId Value")]
    public partial class SurfaceIdValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.SurfaceId _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.SurfaceId);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}