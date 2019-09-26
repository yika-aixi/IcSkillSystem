using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SynchronisationStageFlags Value")]
    public partial class SynchronisationStageFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SynchronisationStageFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SynchronisationStageFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}