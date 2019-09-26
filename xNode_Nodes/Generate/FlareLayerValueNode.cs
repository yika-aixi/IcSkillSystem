using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FlareLayer Value")]
    public partial class FlareLayerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FlareLayer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FlareLayer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}