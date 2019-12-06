using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys
{
    public interface IIcSkSEntityManager
    {
        FasterReadOnlyList<IIcSkSEntity> Entitys { get; }
        
        IBuffManager BuffManager { get;}

        IIcSkSEntity CreateEntity();
        
        IIcSkSEntity CreateEntity(int id);

        bool DestroyEntity(int id);
        
        bool DestroyEntity(IIcSkSEntity entity);

        void Update();

        void AddBuff<T>(IIcSkSEntity entity, T buff) where T : IBuffDataComponent;
        
        bool RemoveBuff<T>(IIcSkSEntity entity,T buff) where T : IBuffDataComponent;

        bool HasBuff<T>(IIcSkSEntity entity, T buff) where T : IBuffDataComponent;
    }

    public interface IStructIcSkSEntityManager : IIcSkSEntityManager
    {
        new void AddBuff<T>(IIcSkSEntity entity, T buff) where T :struct, IBuffDataComponent;
        
        new bool RemoveBuff<T>(IIcSkSEntity entity,T buff) where T :struct, IBuffDataComponent;

        new bool HasBuff<T>(IIcSkSEntity entity, T buff) where T :struct, IBuffDataComponent;
    }
}