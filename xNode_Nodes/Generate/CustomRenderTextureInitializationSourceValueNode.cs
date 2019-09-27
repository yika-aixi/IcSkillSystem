using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CustomRenderTextureInitializationSource Value")]
    public partial class CustomRenderTextureInitializationSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CustomRenderTextureInitializationSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CustomRenderTextureInitializationSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}