using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LayerMask Value")]
    public partial class LayerMaskValueNode:ValueNode<IcVariableLayerMask>
    {
        [SerializeField]
        private UnityEngine.LayerMask _value;
   
        private IcVariableLayerMask _variableValue = new IcVariableLayerMask();
   
        protected override IcVariableLayerMask GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableLayerMask:ValueInfo<UnityEngine.LayerMask>
    {
    }
}