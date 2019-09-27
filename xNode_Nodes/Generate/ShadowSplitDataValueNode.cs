using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowSplitData Value")]
    public partial class ShadowSplitDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShadowSplitData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShadowSplitData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}