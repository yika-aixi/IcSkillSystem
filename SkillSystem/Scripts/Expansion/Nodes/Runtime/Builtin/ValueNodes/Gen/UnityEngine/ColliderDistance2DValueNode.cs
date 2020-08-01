using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ColliderDistance2D Value")]
    public partial class ColliderDistance2DValueNode:ValueNode<IcVariableColliderDistance2D>
    {
        [SerializeField]
        private UnityEngine.ColliderDistance2D _value;
   
        private IcVariableColliderDistance2D _variableValue = new IcVariableColliderDistance2D();
   
        protected override IcVariableColliderDistance2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}