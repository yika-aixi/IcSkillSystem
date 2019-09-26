using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Projector Value")]
    public partial class ProjectorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Projector _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Projector);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}