//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//2019年12月15日-11:25
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks.GroupValueNode
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Group variable/Get")]
    public class GetGroupVariableValueNode:DynamicValueNode
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private string _key;
        
        protected override object GetDynamicValue()
        {
            return SkillGroup.GetVariableValue(GetInputValue(nameof(_key), _key));
        }
    }
}