using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2Int Value")]
    public partial class Vector2IntValueNode:ValueNode<ValueInfo<UnityEngine.Vector2Int>>
    {
        [SerializeField]
        private UnityEngine.Vector2Int _value;
   
        private ValueInfo<UnityEngine.Vector2Int> _variableValue;
   
        protected override ValueInfo<UnityEngine.Vector2Int> GetTValue()
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