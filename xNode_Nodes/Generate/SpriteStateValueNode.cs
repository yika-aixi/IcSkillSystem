using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/SpriteState Value")]
    public partial class SpriteStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.SpriteState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.SpriteState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}