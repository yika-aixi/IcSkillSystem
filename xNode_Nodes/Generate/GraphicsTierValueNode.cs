using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsTier Value")]
    public partial class GraphicsTierValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.GraphicsTier _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.GraphicsTier);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}