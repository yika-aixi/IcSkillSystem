using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs
{
    public interface IBuffManager
    {
        FasterReadOnlyList<IIcSkSEntity> Entitys { get; }
        
        IBuffManager AddBuffSystem<TBuffType>(IBuffSystem buffSystem) where TBuffType : IBuffDataComponent;

        void Update();

        void AddEntity(IIcSkSEntity entity);

        void RemoveEntity(IIcSkSEntity entity);

        void AddBuff<TBuff>(IIcSkSEntity entity, in TBuff buff);

        TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : IBuffDataComponent;

        TBuff GetBuffData<TBuff>(IIcSkSEntity entity, int index) where TBuff : IBuffDataComponent;

        void SetBuffData<TBuff>(IIcSkSEntity entity, in TBuff buff, int index) where TBuff : IBuffDataComponent;

        bool RemoveBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        bool HasBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : IBuffDataComponent;

        bool HasBuff(IIcSkSEntity entity, Type buffType);
        
        bool HasBuff(IIcSkSEntity entity, Type buffType, IBuffDataComponent buff);

        IEnumerable<TBuff> GetBuffs<TBuff>(IIcSkSEntity entity, Func<TBuff,bool> condition) where TBuff : IBuffDataComponent;

        FasterReadOnlyList<TBuff> GetBuffs<TBuff>(IIcSkSEntity entity) where TBuff : IBuffDataComponent;
        
        IEnumerable<IBuffDataComponent> GetAllBuff(IIcSkSEntity entity);

        int GetBuffCount<TBuff>(IIcSkSEntity entity) where TBuff : IBuffDataComponent;
    }

    public interface IStructBuffManager: IBuffManager
    {
        new IStructBuffManager AddBuffSystem<TBuffType>(IBuffSystem buffSystem) where TBuffType : struct,IBuffDataComponent;
        
        new void AddBuff<TBuff>(IIcSkSEntity entity, in TBuff buff) where TBuff : struct, IBuffDataComponent;

        new TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : struct, IBuffDataComponent;

        new TBuff GetBuffData<TBuff>(IIcSkSEntity entity, int index) where TBuff : struct, IBuffDataComponent;

        new void SetBuffData<TBuff>(IIcSkSEntity entity, in TBuff buff, int index)
            where TBuff : struct, IBuffDataComponent;

        new bool RemoveBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new bool HasBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : struct, IBuffDataComponent;

        new FasterReadOnlyList<TBuff> GetBuffs<TBuff>(IIcSkSEntity entity) where TBuff : struct, IBuffDataComponent;

        new int GetBuffCount<TBuff>(IIcSkSEntity entity) where TBuff : struct, IBuffDataComponent;
    }
}