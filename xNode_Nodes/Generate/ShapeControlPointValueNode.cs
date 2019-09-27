using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/SpriteShapeModule/ShapeControlPoint Value")]
    public partial class ShapeControlPointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.U2D.ShapeControlPoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.U2D.ShapeControlPoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}