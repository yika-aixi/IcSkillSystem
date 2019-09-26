using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteTileMode Value")]
    public partial class SpriteTileModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteTileMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteTileMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}