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
        
        IBuffManager AddBuffSystem<TBuffType>(IBuffSystem buffSystem) where TBuffType : IBuffData;

        void Update();

        void AddEntity(IIcSkSEntity entity);

        void RemoveEntity(IIcSkSEntity entity);

        void AddBuff<TBuff>(IIcSkSEntity entity, in TBuff buff);

        TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : IBuffData;

        TBuff GetBuffData<TBuff>(IIcSkSEntity entity, int index) where TBuff : IBuffData;

        void SetBuffData<TBuff>(IIcSkSEntity entity, in TBuff buff, int index) where TBuff : IBuffData;

        bool RemoveBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : IBuffData;

        bool HasBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : IBuffData;

        bool HasBuff(IIcSkSEntity entity, Type buffType);
        
        bool HasBuff(IIcSkSEntity entity, Type buffType, IBuffData buff);

        IEnumerable<TBuff> GetBuffs<TBuff>(IIcSkSEntity entity, Func<TBuff,bool> condition) where TBuff : IBuffData;

        FasterReadOnlyList<TBuff> GetBuffs<TBuff>(IIcSkSEntity entity) where TBuff : IBuffData;
        
        IEnumerable<IBuffData> GetAllBuff(IIcSkSEntity entity);

        int GetBuffCount<TBuff>(IIcSkSEntity entity) where TBuff : IBuffData;
    }

    public interface IStructBuffManager: IBuffManager
    {
        new IStructBuffManager AddBuffSystem<TBuffType>(IBuffSystem buffSystem) where TBuffType : struct,IBuffData;
        
        new void AddBuff<TBuff>(IIcSkSEntity entity, in TBuff buff) where TBuff : struct, IBuffData;

        new TBuff GetCurrentBuffData<TBuff>(int index) where TBuff : struct, IBuffData;

        new TBuff GetBuffData<TBuff>(IIcSkSEntity entity, int index) where TBuff : struct, IBuffData;

        new void SetBuffData<TBuff>(IIcSkSEntity entity, in TBuff buff, int index)
            where TBuff : struct, IBuffData;

        new bool RemoveBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : struct, IBuffData;

        new bool HasBuff<TBuff>(IIcSkSEntity entity, TBuff buff) where TBuff : struct, IBuffData;

        new FasterReadOnlyList<TBuff> GetBuffs<TBuff>(IIcSkSEntity entity) where TBuff : struct, IBuffData;

        new int GetBuffCount<TBuff>(IIcSkSEntity entity) where TBuff : struct, IBuffData;
    }
}