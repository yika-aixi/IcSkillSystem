using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/CharacterInfo Value")]
    public partial class CharacterInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CharacterInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CharacterInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}