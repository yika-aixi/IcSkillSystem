using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/WaitForPresentSyncPoint Value")]
    public partial class WaitForPresentSyncPointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Rendering.WaitForPresentSyncPoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Rendering.WaitForPresentSyncPoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}