using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteDrawMode Value")]
    public partial class SpriteDrawModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteDrawMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteDrawMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}