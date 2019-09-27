using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CullingResults Value")]
    public partial class CullingResultsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CullingResults _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CullingResults);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}