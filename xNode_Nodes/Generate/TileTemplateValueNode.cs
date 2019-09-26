using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TileTemplate Value")]
    public partial class TileTemplateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WSA.TileTemplate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WSA.TileTemplate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}