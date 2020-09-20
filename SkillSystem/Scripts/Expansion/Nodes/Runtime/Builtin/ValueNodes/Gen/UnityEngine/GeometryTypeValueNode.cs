using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/GeometryType Value")]
    public partial class GeometryTypeValueNode:ValueNode<ValueInfo<UnityEngine.CompositeCollider2D.GeometryType>>
    {
        [SerializeField]
        private UnityEngine.CompositeCollider2D.GeometryType _value;
   
        private ValueInfo<UnityEngine.CompositeCollider2D.GeometryType> _variableValue;
   
        protected override ValueInfo<UnityEngine.CompositeCollider2D.GeometryType> GetTValue()
        {
            _variableValue.Value = _value;
            
            return _variableValue;
        }

        public override void OnStart()
        {
            base.OnStart();

            _variableValue = _value;
        }

        public override void OnStop()
        {
            base.OnStop();
            
            _variableValue.Release();

            _variableValue = null;
        }
    }
}