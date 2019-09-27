using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/VisibleLight Value")]
    public partial class VisibleLightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.VisibleLight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.VisibleLight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}