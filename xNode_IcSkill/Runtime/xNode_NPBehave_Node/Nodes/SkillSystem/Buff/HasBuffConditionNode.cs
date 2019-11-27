using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems.Buff
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Buff/Has Condition")]
    public class HasBuffConditionNode:ABuffNode
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private Stops _stops;
        
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        protected Node DecorateeNode;
        
        protected override Node Execute()
        {
            return new Condition(_hasBuff,GetInputValue(nameof(_stops),_stops),GetInputValue(nameof(DecorateeNode),DecorateeNode));
        }

        private bool _hasBuff()
        {
            return BuffFactory.HasBuff(EntityManager, Target, Buff);
        }

//        private IBuffDataComponent _hasBuff()
//        {
//            //todo 暂时先这样写下
//            Debug.LogError("空值比较 -----------");
//            return (IBuffDataComponent) Activator.CreateInstance(BuffType);
//        }
    }
}