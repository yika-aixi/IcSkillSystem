using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpritePackingMode Value")]
    public partial class SpritePackingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpritePackingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpritePackingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}