using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IIcSkSEntityManager<TBM> where TBM : INewBuffManager
    {
        TBM BuffManager { get;}

        BuffEntity CreateEntity();
        
        BuffEntity CreateEntity(int id);

        bool DestroyEntity(int id);
        
        bool DestroyEntity(BuffEntity entity);

        void Update();

        void AddBuff<T>(BuffEntity entity, T buff) where T : IBuffDataComponent;
        
        bool RemoveBuff<T>(BuffEntity entity,T buff) where T : IBuffDataComponent;

        bool HasBuff<T>(BuffEntity entity, T buff) where T : IBuffDataComponent;
    }

    public interface IStructIcSkSEntityManager<TBM> : IIcSkSEntityManager<TBM> where TBM : INewBuffManager
    {
        new void AddBuff<T>(BuffEntity entity, T buff) where T :struct, IBuffDataComponent;
        
        new bool RemoveBuff<T>(BuffEntity entity,T buff) where T :struct, IBuffDataComponent;

        new bool HasBuff<T>(BuffEntity entity, T buff) where T :struct, IBuffDataComponent;
    }
}