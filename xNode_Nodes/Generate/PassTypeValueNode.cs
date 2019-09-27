using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PassType Value")]
    public partial class PassTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.PassType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.PassType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}