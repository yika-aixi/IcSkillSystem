using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TileForegroundText Value")]
    public partial class TileForegroundTextValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WSA.TileForegroundText _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WSA.TileForegroundText);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}