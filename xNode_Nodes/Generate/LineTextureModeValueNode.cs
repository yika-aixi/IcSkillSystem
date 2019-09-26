using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LineTextureMode Value")]
    public partial class LineTextureModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LineTextureMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LineTextureMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}