using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/UnloadSceneOptions Value")]
    public partial class UnloadSceneOptionsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SceneManagement.UnloadSceneOptions _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SceneManagement.UnloadSceneOptions);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}