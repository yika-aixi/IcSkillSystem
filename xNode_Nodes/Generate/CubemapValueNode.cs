using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Cubemap Value")]
    public partial class CubemapValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Cubemap _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Cubemap);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}