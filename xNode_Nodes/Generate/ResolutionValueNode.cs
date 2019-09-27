using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Resolution Value")]
    public partial class ResolutionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Resolution _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Resolution);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}