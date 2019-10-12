using System;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
{
    public class IcSkSEntityManager:IStructIcSkSEntityManager<BuffManager,IcSkSEntity>
    {
        private FasterList<IcSkSEntity> _entitys;

        public FasterReadOnlyList<IcSkSEntity> Entitys => _entitys.AsReadOnly();
        
        public BuffManager BuffManager { get; }
        
        public IcSkSEntityManager(BuffManager buffManager)
        {
            BuffManager = buffManager;
            _entitys = new FasterList<IcSkSEntity>();
        }

        private int _id;
        
        public IcSkSEntity CreateEntity()
        {
            ++_id;

            return CreateEntity(_id);
        }

        public IcSkSEntity CreateEntity(int id)
        {
            IcSkSEntity entity = id;
            
            BuffManager.AddEntity(entity);
            
            return entity;
        }

        public bool DestroyEntity(int id)
        {
            return DestroyEntity((IcSkSEntity) id);
        }

        public bool DestroyEntity(IcSkSEntity entity)
        {
            if (!_checkEntity(entity))
            {
                return false;
            }
            
            BuffManager.RemoveEntity(entity);

            return true;
        }

        private bool _checkEntity(IcSkSEntity entity)
        {
            return _entitys.Contains(entity);
        }

        public void Update()
        {
            BuffManager.Update();
        }

        public void AddBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            BuffManager.AddBuff(entity,buff);
        }

        public bool RemoveBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            return BuffManager.RemoveBuff(entity, buff);
        }

        public bool HasBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            return BuffManager.HasBuff(entity, buff);
        }

        public int GetEntityCount()
        {
            return _entitys.Count;
        }

        #region Cover

        void IIcSkSEntityManager<BuffManager,IcSkSEntity>.AddBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<BuffManager,IcSkSEntity>)}");
        }

        bool IIcSkSEntityManager<BuffManager,IcSkSEntity>.RemoveBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<BuffManager,IcSkSEntity>)}");
        }

        bool IIcSkSEntityManager<BuffManager,IcSkSEntity>.HasBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<BuffManager,IcSkSEntity>)}");
        }

        #endregion
    }
}