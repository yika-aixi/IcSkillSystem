using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/Tree Value")]
    public partial class TreeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Tree _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Tree);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}