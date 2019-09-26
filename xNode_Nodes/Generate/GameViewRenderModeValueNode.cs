using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/GameViewRenderMode Value")]
    public partial class GameViewRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.GameViewRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.GameViewRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}