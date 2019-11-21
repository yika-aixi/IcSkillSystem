using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.BuffNodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Buff")]
    public abstract class ASKNode:ANPBehaveNode<Task>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private IIcSkSEntity _entity;

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private IIcSkSEntityManager<IIcSkSEntity> _entityManager;
        
        protected IIcSkSEntity Entity =>  GetInputValue(nameof(_entity), _entity);

        protected IIcSkSEntityManager<IIcSkSEntity> EntityManager =>
            GetInputValue(nameof(_entityManager), _entityManager);
        
        protected sealed override Task GetOutValue()
        {
            return GetTask();
        }

        protected abstract Task GetTask();
    }
}