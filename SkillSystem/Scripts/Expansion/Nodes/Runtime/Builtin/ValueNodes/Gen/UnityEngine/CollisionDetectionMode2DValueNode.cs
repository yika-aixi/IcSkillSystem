using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/CollisionDetectionMode2D Value")]
    public partial class CollisionDetectionMode2DValueNode:ValueNode<IcVariableCollisionDetectionMode2D>
    {
        [SerializeField]
        private UnityEngine.CollisionDetectionMode2D _value;
   
        private IcVariableCollisionDetectionMode2D _variableValue = new IcVariableCollisionDetectionMode2D();
   
        protected override IcVariableCollisionDetectionMode2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}