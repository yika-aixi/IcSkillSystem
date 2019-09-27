using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FrustumPlanes Value")]
    public partial class FrustumPlanesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FrustumPlanes _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FrustumPlanes);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}