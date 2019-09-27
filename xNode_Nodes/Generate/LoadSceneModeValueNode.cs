using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LoadSceneMode Value")]
    public partial class LoadSceneModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SceneManagement.LoadSceneMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SceneManagement.LoadSceneMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}