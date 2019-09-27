using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SphericalHarmonicsL2 Value")]
    public partial class SphericalHarmonicsL2ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SphericalHarmonicsL2 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SphericalHarmonicsL2);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}