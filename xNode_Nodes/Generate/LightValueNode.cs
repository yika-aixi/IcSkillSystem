using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Light Value")]
    public partial class LightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Light _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Light);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}