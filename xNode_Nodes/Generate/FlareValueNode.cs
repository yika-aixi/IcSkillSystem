using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Flare Value")]
    public partial class FlareValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Flare _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Flare);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}