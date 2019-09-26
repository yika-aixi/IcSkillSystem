using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/GridModule/Grid Value")]
    public partial class GridValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Grid _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Grid);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}