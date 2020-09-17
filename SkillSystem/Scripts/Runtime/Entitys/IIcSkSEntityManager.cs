using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IIcSkSEntityManager<TEntity> where TEntity : IIcSkSEntity
    {
        FasterReadOnlyList<TEntity> Entitys { get; }
        
        IBuffManager BuffManager { get;}

        TEntity CreateEntity();
        
        TEntity CreateEntity(int id);

        bool DestroyEntity(int id);
        
        bool DestroyEntity(TEntity entity);

        void Update();

        void AddBuff<T>(TEntity entity, T buff) where T : IBuffData;
        
        bool RemoveBuff<T>(TEntity entity,T buff) where T : IBuffData;

        bool HasBuff<T>(TEntity entity, T buff) where T : IBuffData;
    }

    public interface IStructIcSkSEntityManager<TEntity> : IIcSkSEntityManager<TEntity> where TEntity : IIcSkSEntity
    {
        new void AddBuff<T>(TEntity entity, T buff) where T :struct, IBuffData;
        
        new bool RemoveBuff<T>(TEntity entity,T buff) where T :struct, IBuffData;

        new bool HasBuff<T>(TEntity entity, T buff) where T :struct, IBuffData;
    }
}