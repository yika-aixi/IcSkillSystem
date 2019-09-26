using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BillboardRenderer Value")]
    public partial class BillboardRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BillboardRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BillboardRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}