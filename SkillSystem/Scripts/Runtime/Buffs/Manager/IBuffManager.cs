using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs
{
    public interface IBuffManager<in TEntity> where TEntity : IIcSkSEntity
    {
        IEnumerable<IBuffDataComponent> GetAllBuff(TEntity entity);
    }

    public interface IBuffManager<in T,in TEntity>:IBuffManager<TEntity> where T : IBuffSystem where TEntity : IIcSkSEntity
    {
        IBuffManager<T,TEntity> AddBuffSystem(T buffSystem);

        void Update();

        void AddEntity(TEntity entity);

        void RemoveEntity(TEntity entity);

        void AddBuff<TBuff>(TEntity entity, in TBuff buff);

        TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : IBuffDataComponent;

        TBuff GetBuffData<TBuff>(TEntity entity, int index) where TBuff : IBuffDataComponent;

        void SetBuffData<TBuff>(TEntity entity, in TBuff buff, int index) where TBuff : IBuffDataComponent;

        bool RemoveBuff<TBuff>(TEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        bool HasBuff<TBuff>(TEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        bool HasBuff(TEntity entity, Type buffType);
        
        bool HasBuff(TEntity entity, Type buffType, IBuffDataComponent buff);

        IEnumerable<TBuff> GetBuffs<TBuff>(TEntity entity, TBuff condition) where TBuff : IBuffDataComponent;

        FasterReadOnlyList<TBuff> GetBuffs<TBuff>(TEntity entity) where TBuff : IBuffDataComponent;

        int GetBuffCount<TBuff>(TEntity entity) where TBuff : IBuffDataComponent;
    }

    public interface IStructBuffManager<in T,in TEntity> : IBuffManager<T,TEntity> where T : IBuffSystem where TEntity : struct,IIcSkSEntity,IEquatable<TEntity>
    {
        new void AddBuff<TBuff>(TEntity entity, in TBuff buff) where TBuff : struct, IBuffDataComponent;

        new TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : struct, IBuffDataComponent;

        new TBuff GetBuffData<TBuff>(TEntity entity, int index) where TBuff : struct, IBuffDataComponent;

        new void SetBuffData<TBuff>(TEntity entity, in TBuff buff, int index)
            where TBuff : struct, IBuffDataComponent;

        new bool RemoveBuff<TBuff>(TEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new bool HasBuff<TBuff>(TEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new IEnumerable<TBuff> GetBuffs<TBuff>(TEntity entity, TBuff condition)
            where TBuff : struct, IBuffDataComponent;

        new FasterReadOnlyList<TBuff> GetBuffs<TBuff>(TEntity entity) where TBuff : struct, IBuffDataComponent;

        new int GetBuffCount<TBuff>(TEntity entity) where TBuff : struct, IBuffDataComponent;
    }
}