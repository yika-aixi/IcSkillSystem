using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/PatchExtents Value")]
    public partial class PatchExtentsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PatchExtents _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PatchExtents);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}