using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Scene Value")]
    public partial class SceneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SceneManagement.Scene _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SceneManagement.Scene);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}