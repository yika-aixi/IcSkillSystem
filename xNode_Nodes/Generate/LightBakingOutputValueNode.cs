using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightBakingOutput Value")]
    public partial class LightBakingOutputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightBakingOutput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightBakingOutput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}