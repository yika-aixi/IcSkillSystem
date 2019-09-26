using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/PlaneAlignment Value")]
    public partial class PlaneAlignmentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.PlaneAlignment _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.PlaneAlignment);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}