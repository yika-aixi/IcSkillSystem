using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs
{
    public interface INewBuffManager
    {
    }

    public interface INewBuffManager<in T>:INewBuffManager where T : IBuffSystem
    {
        INewBuffManager<T> AddBuffSystem(T buffSystem);

        void Update();

        void AddEntity(BuffEntity entity);

        void RemoveEntity(BuffEntity entity);

        void AddBuff<TBuff>(BuffEntity entity, in TBuff buff) where TBuff : IBuffDataComponent;

        TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : IBuffDataComponent;

        TBuff GetBuffData<TBuff>(BuffEntity entity, int index) where TBuff : IBuffDataComponent;

        void SetBuffData<TBuff>(BuffEntity entity, in TBuff buff, int index) where TBuff : IBuffDataComponent;

        bool RemoveBuff<TBuff>(BuffEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        bool HasBuff<TBuff>(BuffEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        IEnumerable<TBuff> GetBuffs<TBuff>(BuffEntity entity, TBuff condition) where TBuff : IBuffDataComponent;

        FasterReadOnlyList<TBuff> GetBuffs<TBuff>(BuffEntity entity) where TBuff : IBuffDataComponent;

        int GetBuffCount<TBuff>(BuffEntity entity) where TBuff : IBuffDataComponent;
    }

    public interface IStructBuffManager<in T> : INewBuffManager<T> where T : IBuffSystem
    {
        new void AddBuff<TBuff>(BuffEntity entity, in TBuff buff) where TBuff : struct, IBuffDataComponent;

        new TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : struct, IBuffDataComponent;

        new TBuff GetBuffData<TBuff>(BuffEntity entity, int index) where TBuff : struct, IBuffDataComponent;

        new void SetBuffData<TBuff>(BuffEntity entity, in TBuff buff, int index)
            where TBuff : struct, IBuffDataComponent;

        new bool RemoveBuff<TBuff>(BuffEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new bool HasBuff<TBuff>(BuffEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new IEnumerable<TBuff> GetBuffs<TBuff>(BuffEntity entity, TBuff condition)
            where TBuff : struct, IBuffDataComponent;

        new FasterReadOnlyList<TBuff> GetBuffs<TBuff>(BuffEntity entity) where TBuff : struct, IBuffDataComponent;

        new int GetBuffCount<TBuff>(BuffEntity entity) where TBuff : struct, IBuffDataComponent;
    }
}