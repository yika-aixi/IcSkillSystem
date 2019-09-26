using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsJobsSyncPoint Value")]
    public partial class GraphicsJobsSyncPointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Rendering.GraphicsJobsSyncPoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Rendering.GraphicsJobsSyncPoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}