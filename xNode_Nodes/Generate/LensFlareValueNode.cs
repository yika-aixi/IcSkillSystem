using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LensFlare Value")]
    public partial class LensFlareValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LensFlare _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LensFlare);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}