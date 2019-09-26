using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FullScreenMovieControlMode Value")]
    public partial class FullScreenMovieControlModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FullScreenMovieControlMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FullScreenMovieControlMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}