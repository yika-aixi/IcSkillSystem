using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LoadSceneParameters Value")]
    public partial class LoadSceneParametersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SceneManagement.LoadSceneParameters _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SceneManagement.LoadSceneParameters);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}