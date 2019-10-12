using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IIcSkSEntityManager<out TBM,TEntity> where TBM : IBuffManager<TEntity> where TEntity : IIcSkSEntity
    {
        FasterReadOnlyList<TEntity> Entitys { get; }
        
        TBM BuffManager { get;}

        TEntity CreateEntity();
        
        TEntity CreateEntity(int id);

        bool DestroyEntity(int id);
        
        bool DestroyEntity(TEntity entity);

        void Update();

        void AddBuff<T>(TEntity entity, T buff) where T : IBuffDataComponent;
        
        bool RemoveBuff<T>(TEntity entity,T buff) where T : IBuffDataComponent;

        bool HasBuff<T>(TEntity entity, T buff) where T : IBuffDataComponent;
    }

    public interface IStructIcSkSEntityManager<out TBM,TEntity> : IIcSkSEntityManager<TBM,TEntity> where TBM : IBuffManager<TEntity> where TEntity : IIcSkSEntity
    {
        new void AddBuff<T>(TEntity entity, T buff) where T :struct, IBuffDataComponent;
        
        new bool RemoveBuff<T>(TEntity entity,T buff) where T :struct, IBuffDataComponent;

        new bool HasBuff<T>(TEntity entity, T buff) where T :struct, IBuffDataComponent;
    }
}