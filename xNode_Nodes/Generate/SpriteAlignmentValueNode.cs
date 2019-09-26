using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteAlignment Value")]
    public partial class SpriteAlignmentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteAlignment _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteAlignment);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}