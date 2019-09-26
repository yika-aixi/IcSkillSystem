using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/GridModule/GridLayout Value")]
    public partial class GridLayoutValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GridLayout _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GridLayout);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}