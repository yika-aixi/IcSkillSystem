using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/EnforceJobResult Value")]
    public partial class EnforceJobResultValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Collections.LowLevel.Unsafe.EnforceJobResult _value;

        public override Type ValueType { get; } = typeof(Unity.Collections.LowLevel.Unsafe.EnforceJobResult);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}