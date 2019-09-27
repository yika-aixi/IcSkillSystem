using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraPlayable Value")]
    public partial class CameraPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Playables.CameraPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Playables.CameraPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}