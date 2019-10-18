using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
{
    public partial class IcSkSEntityManager:IStructIcSkSEntityManager<IBuffSystem,IcSkSEntity>
    {
        private FasterList<IcSkSEntity> _entitys;

        public FasterReadOnlyList<IcSkSEntity> Entitys => _entitys.AsReadOnly();
        public IBuffManager<IBuffSystem, IcSkSEntity> BuffManager { get; }

        public IcSkSEntityManager(IBuffManager<IBuffSystem, IcSkSEntity> buffManager)
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

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns>如果已经存在将返回id为-1的实体</returns>
        public IcSkSEntity CreateEntity(int id)
        {
            IcSkSEntity entity = id;

            if (_checkEntity(entity))
            {
                return -1;
            }
            
            _entitys.Add(entity);
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

            _entitys.Remove(entity);
            
            BuffManager.RemoveEntity(entity);

            return true;
        }

        private bool _checkEntity(in IcSkSEntity entity)
        {
            return _entitys.Contains(entity);
        }

        public void Update()
        {
            BuffManager.Update();
        }

        public void AddBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            if (!_checkEntity(entity))
            {
                return;
            }
            
            BuffManager.AddBuff(entity,buff);
        }

        public bool RemoveBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            if (!_checkEntity(entity))
            {
                return false;
            }
            
            return BuffManager.RemoveBuff(entity, buff);
        }

        public bool HasBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            if (!_checkEntity(entity))
            {
                return false;
            }
            
            return BuffManager.HasBuff(entity, buff);
        }

        public int GetEntityCount()
        {
            return _entitys.Count;
        }

        #region Cover

        void IIcSkSEntityManager<IBuffSystem, IcSkSEntity>.AddBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IBuffSystem,IcSkSEntity>)}");
        }

        bool IIcSkSEntityManager<IBuffSystem, IcSkSEntity>.RemoveBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IBuffSystem,IcSkSEntity>)}");
        }

        bool IIcSkSEntityManager<IBuffSystem, IcSkSEntity>.HasBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IBuffSystem,IcSkSEntity>)}");
        }

        #endregion
    }
}