using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TexturePlayableOutput Value")]
    public partial class TexturePlayableOutputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Playables.TexturePlayableOutput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Playables.TexturePlayableOutput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}