using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Sprite Value")]
    public partial class SpriteValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Sprite _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Sprite);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}