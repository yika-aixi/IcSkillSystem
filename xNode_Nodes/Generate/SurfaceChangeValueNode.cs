using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/SurfaceChange Value")]
    public partial class SurfaceChangeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.SurfaceChange _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.SurfaceChange);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}