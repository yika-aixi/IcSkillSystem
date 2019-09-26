using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SkinnedMeshRenderer Value")]
    public partial class SkinnedMeshRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SkinnedMeshRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SkinnedMeshRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}