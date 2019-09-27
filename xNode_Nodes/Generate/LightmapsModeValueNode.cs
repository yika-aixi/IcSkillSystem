using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightmapsMode Value")]
    public partial class LightmapsModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightmapsMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightmapsMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}