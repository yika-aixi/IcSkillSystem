using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/MeshChangeState Value")]
    public partial class MeshChangeStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.MeshChangeState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.MeshChangeState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}