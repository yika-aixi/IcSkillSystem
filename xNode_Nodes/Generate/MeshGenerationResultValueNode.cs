using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/MeshGenerationResult Value")]
    public partial class MeshGenerationResultValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.MeshGenerationResult _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.MeshGenerationResult);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}