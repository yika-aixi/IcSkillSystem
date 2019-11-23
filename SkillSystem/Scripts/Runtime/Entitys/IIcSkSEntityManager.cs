using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IIcSkSEntityManager<TEntity> where TEntity : IIcSkSEntity
    {
        FasterReadOnlyList<TEntity> Entitys { get; }
        
        IBuffManager<TEntity> BuffManager { get;}

        TEntity CreateEntity();
        
        TEntity CreateEntity(int id);

        bool DestroyEntity(int id);
        
        bool DestroyEntity(TEntity entity);

        void Update();

        void AddBuff<T>(TEntity entity, T buff) where T : IBuffDataComponent;
        
        bool RemoveBuff<T>(TEntity entity,T buff) where T : IBuffDataComponent;

        bool HasBuff<T>(TEntity entity, T buff) where T : IBuffDataComponent;
    }

    public interface IStructIcSkSEntityManager<TEntity> : IIcSkSEntityManager<TEntity> where TEntity : IIcSkSEntity
    {
        new void AddBuff<T>(TEntity entity, T buff) where T :struct, IBuffDataComponent;
        
        new bool RemoveBuff<T>(TEntity entity,T buff) where T :struct, IBuffDataComponent;

        new bool HasBuff<T>(TEntity entity, T buff) where T :struct, IBuffDataComponent;
    }
}