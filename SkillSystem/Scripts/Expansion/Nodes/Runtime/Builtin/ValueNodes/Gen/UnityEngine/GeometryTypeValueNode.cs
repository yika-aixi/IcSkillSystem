using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/GeometryType Value")]
    public partial class GeometryTypeValueNode:ValueNode<IcVariableGeometryType>
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D.GeometryType _value;
   
        private IcVariableGeometryType _variableValue = new IcVariableGeometryType();
   
        protected override IcVariableGeometryType GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}