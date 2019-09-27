using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DirectorWrapMode Value")]
    public partial class DirectorWrapModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.DirectorWrapMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.DirectorWrapMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}