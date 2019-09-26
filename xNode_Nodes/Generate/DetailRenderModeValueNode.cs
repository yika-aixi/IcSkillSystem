using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TerrainModule/DetailRenderMode Value")]
    public partial class DetailRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.DetailRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.DetailRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}