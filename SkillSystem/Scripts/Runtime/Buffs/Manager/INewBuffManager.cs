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

        void AddEntity(IcSkSEntity entity);

        void RemoveEntity(IcSkSEntity entity);

        void AddBuff<TBuff>(IcSkSEntity entity, in TBuff buff) where TBuff : IBuffDataComponent;

        TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : IBuffDataComponent;

        TBuff GetBuffData<TBuff>(IcSkSEntity entity, int index) where TBuff : IBuffDataComponent;

        void SetBuffData<TBuff>(IcSkSEntity entity, in TBuff buff, int index) where TBuff : IBuffDataComponent;

        bool RemoveBuff<TBuff>(IcSkSEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        bool HasBuff<TBuff>(IcSkSEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        IEnumerable<TBuff> GetBuffs<TBuff>(IcSkSEntity entity, TBuff condition) where TBuff : IBuffDataComponent;

        FasterReadOnlyList<TBuff> GetBuffs<TBuff>(IcSkSEntity entity) where TBuff : IBuffDataComponent;

        int GetBuffCount<TBuff>(IcSkSEntity entity) where TBuff : IBuffDataComponent;
    }

    public interface IStructBuffManager<in T> : INewBuffManager<T> where T : IBuffSystem
    {
        new void AddBuff<TBuff>(IcSkSEntity entity, in TBuff buff) where TBuff : struct, IBuffDataComponent;

        new TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : struct, IBuffDataComponent;

        new TBuff GetBuffData<TBuff>(IcSkSEntity entity, int index) where TBuff : struct, IBuffDataComponent;

        new void SetBuffData<TBuff>(IcSkSEntity entity, in TBuff buff, int index)
            where TBuff : struct, IBuffDataComponent;

        new bool RemoveBuff<TBuff>(IcSkSEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new bool HasBuff<TBuff>(IcSkSEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new IEnumerable<TBuff> GetBuffs<TBuff>(IcSkSEntity entity, TBuff condition)
            where TBuff : struct, IBuffDataComponent;

        new FasterReadOnlyList<TBuff> GetBuffs<TBuff>(IcSkSEntity entity) where TBuff : struct, IBuffDataComponent;

        new int GetBuffCount<TBuff>(IcSkSEntity entity) where TBuff : struct, IBuffDataComponent;
    }
}