using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CullingOptions Value")]
    public partial class CullingOptionsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CullingOptions _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CullingOptions);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}