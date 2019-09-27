using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Folder Value")]
    public partial class FolderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WSA.Folder _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WSA.Folder);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}