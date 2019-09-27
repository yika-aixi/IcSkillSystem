using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/FaceInfo Value")]
    public partial class FaceInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.FaceInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.FaceInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}