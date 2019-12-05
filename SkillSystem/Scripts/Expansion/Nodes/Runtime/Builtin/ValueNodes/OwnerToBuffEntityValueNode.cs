using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Entity/Go To Entity Value")]
    public class OwnerToBuffEntityValueNode:ValueNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private IcSkSEntityManager _entityManager;
        
        public override Type ValueType { get; } = typeof(IcSkSEntity);
        
        protected override object GetOutValue()
        {
            var entityManager = GetInputValue(nameof(_entityManager), _entityManager);

            if (entityManager == null)
            {
                return new IcSkSEntity(-1);
            }

            return entityManager.FindBindEntity(SkillGroup.Owner.gameObject);
        }
    }
}