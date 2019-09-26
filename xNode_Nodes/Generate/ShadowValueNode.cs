using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Shadow Value")]
    public partial class ShadowValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Shadow _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Shadow);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}