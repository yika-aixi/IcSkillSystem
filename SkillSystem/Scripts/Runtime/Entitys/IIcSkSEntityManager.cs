using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IIcSkSEntityManager<TBM> where TBM : IBuffManager
    {
        TBM BuffManager { get;}

        IcSkSEntity CreateEntity();
        
        IcSkSEntity CreateEntity(int id);

        bool DestroyEntity(int id);
        
        bool DestroyEntity(IcSkSEntity entity);

        void Update();

        void AddBuff<T>(IcSkSEntity entity, T buff) where T : IBuffDataComponent;
        
        bool RemoveBuff<T>(IcSkSEntity entity,T buff) where T : IBuffDataComponent;

        bool HasBuff<T>(IcSkSEntity entity, T buff) where T : IBuffDataComponent;
    }

    public interface IStructIcSkSEntityManager<TBM> : IIcSkSEntityManager<TBM> where TBM : IBuffManager
    {
        new void AddBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent;
        
        new bool RemoveBuff<T>(IcSkSEntity entity,T buff) where T :struct, IBuffDataComponent;

        new bool HasBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent;
    }
}