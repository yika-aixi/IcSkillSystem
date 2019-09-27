using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/TextGenerationSettings Value")]
    public partial class TextGenerationSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextGenerationSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextGenerationSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}