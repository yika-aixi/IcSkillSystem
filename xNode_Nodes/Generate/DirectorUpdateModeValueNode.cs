using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DirectorUpdateMode Value")]
    public partial class DirectorUpdateModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.DirectorUpdateMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.DirectorUpdateMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}