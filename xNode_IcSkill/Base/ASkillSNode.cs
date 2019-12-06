//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月23日-20:11
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    public abstract class ASkillSNode :ANPBehaveNode<Node>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private IIcSkSEntityManager<IIcSkSEntity> _entityManager;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private IIcSkSEntity _target;

        protected IIcSkSEntityManager<IIcSkSEntity> EntityManager => GetInputValue(nameof(_entityManager),_entityManager);

        public IIcSkSEntity Target => GetInputValue(nameof(_target),_target);
    }
}