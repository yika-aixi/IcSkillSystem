using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/NativeArrayOptions Value")]
    public partial class NativeArrayOptionsValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Collections.NativeArrayOptions _value;

        public override Type ValueType { get; } = typeof(Unity.Collections.NativeArrayOptions);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}