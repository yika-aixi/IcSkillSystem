using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LocalPhysicsMode Value")]
    public partial class LocalPhysicsModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SceneManagement.LocalPhysicsMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SceneManagement.LocalPhysicsMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}