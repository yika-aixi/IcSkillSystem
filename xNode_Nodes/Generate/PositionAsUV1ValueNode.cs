using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/PositionAsUV1 Value")]
    public partial class PositionAsUV1ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.PositionAsUV1 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.PositionAsUV1);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}