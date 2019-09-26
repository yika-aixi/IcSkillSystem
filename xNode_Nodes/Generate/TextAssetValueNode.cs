using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextAsset Value")]
    public partial class TextAssetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextAsset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextAsset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}