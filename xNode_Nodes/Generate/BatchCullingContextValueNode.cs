using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BatchCullingContext Value")]
    public partial class BatchCullingContextValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BatchCullingContext _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BatchCullingContext);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}