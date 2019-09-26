using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/MeshVertexAttributes Value")]
    public partial class MeshVertexAttributesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.MeshVertexAttributes _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.MeshVertexAttributes);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}