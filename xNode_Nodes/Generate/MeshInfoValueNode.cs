using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/MeshInfo Value")]
    public partial class MeshInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.MeshInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.MeshInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}