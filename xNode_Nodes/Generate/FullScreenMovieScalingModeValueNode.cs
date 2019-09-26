using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FullScreenMovieScalingMode Value")]
    public partial class FullScreenMovieScalingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FullScreenMovieScalingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FullScreenMovieScalingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}