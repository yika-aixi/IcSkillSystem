using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/PropertySceneHandle Value")]
    public partial class PropertySceneHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.PropertySceneHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.PropertySceneHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}