using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/TreeInstance Value")]
    public partial class TreeInstanceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TreeInstance _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TreeInstance);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}