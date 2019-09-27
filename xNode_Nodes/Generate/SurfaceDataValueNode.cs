using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/SurfaceData Value")]
    public partial class SurfaceDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.SurfaceData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.SurfaceData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}