using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Behaviour Value")]
    public partial class BehaviourValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Behaviour _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Behaviour);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}