using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/MeshGenerationStatus Value")]
    public partial class MeshGenerationStatusValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.MeshGenerationStatus _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.MeshGenerationStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}