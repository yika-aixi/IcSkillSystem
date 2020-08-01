using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RaycastHit2D Value")]
    public partial class RaycastHit2DValueNode:ValueNode<IcVariableRaycastHit2D>
    {
        [SerializeField]
        private UnityEngine.RaycastHit2D _value;
   
        private IcVariableRaycastHit2D _variableValue = new IcVariableRaycastHit2D();
   
        protected override IcVariableRaycastHit2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}