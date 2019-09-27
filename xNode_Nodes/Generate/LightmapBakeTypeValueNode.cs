using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightmapBakeType Value")]
    public partial class LightmapBakeTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightmapBakeType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightmapBakeType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}