using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightEvent Value")]
    public partial class LightEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.LightEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.LightEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}