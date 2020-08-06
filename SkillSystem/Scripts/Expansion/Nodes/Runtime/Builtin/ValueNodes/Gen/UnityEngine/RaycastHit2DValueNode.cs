using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RaycastHit2D Value")]
    public partial class RaycastHit2DValueNode:ValueNode<ValueInfo<UnityEngine.RaycastHit2D>>
    {
        [SerializeField]
        private UnityEngine.RaycastHit2D _value;
   
        private ValueInfo<UnityEngine.RaycastHit2D> _variableValue = new ValueInfo<UnityEngine.RaycastHit2D>();
   
        protected override ValueInfo<UnityEngine.RaycastHit2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}