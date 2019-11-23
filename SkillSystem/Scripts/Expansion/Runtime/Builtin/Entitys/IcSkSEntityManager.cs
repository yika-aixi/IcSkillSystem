using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
{
    public partial class IcSkSEntityManager:IStructIcSkSEntityManager<IcSkSEntity>,IStructIcSkSEntityManager<IIcSkSEntity>
    {
        private FasterList<IcSkSEntity> _entitys;

        public FasterReadOnlyList<IcSkSEntity> Entitys => _entitys.AsReadOnly();

        public IBuffManager<IcSkSEntity> BuffManager { get; }

        private IStructBuffManager<IcSkSEntity> SBuffManager => (IStructBuffManager<IcSkSEntity>) BuffManager;

        public IcSkSEntityManager(IBuffManager<IcSkSEntity> buffManager)
        {
            this.BuffManager = buffManager;
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
            SBuffManager.AddEntity(entity);
            
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
            
            SBuffManager.RemoveEntity(entity);

            return true;
        }

        private bool _checkEntity(in IcSkSEntity entity)
        {
            return _entitys.Contains(entity);
        }

        public void Update()
        {
            SBuffManager.Update();
        }

        public void AddBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            if (!_checkEntity(entity))
            {
                return;
            }
            
            SBuffManager.AddBuff(entity,buff);
        }

        public bool RemoveBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            if (!_checkEntity(entity))
            {
                return false;
            }
            
            return SBuffManager.RemoveBuff(entity, buff);
        }

        public bool HasBuff<T>(IcSkSEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            if (!_checkEntity(entity))
            {
                return false;
            }
            
            return SBuffManager.HasBuff(entity, buff);
        }

        public int GetEntityCount()
        {
            return _entitys.Count;
        }

        #region Cover

        FasterReadOnlyList<IIcSkSEntity> IIcSkSEntityManager<IIcSkSEntity>.Entitys => throw new NotImplementedException();

        IBuffManager<IIcSkSEntity> IIcSkSEntityManager<IIcSkSEntity>.BuffManager => throw new NotImplementedException();

        IIcSkSEntity IIcSkSEntityManager<IIcSkSEntity>.CreateEntity()
        {
            throw new NotImplementedException();
        }

        IIcSkSEntity IIcSkSEntityManager<IIcSkSEntity>.CreateEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool DestroyEntity(IIcSkSEntity entity)
        {
            throw new NotImplementedException();
        }

        void IIcSkSEntityManager<IIcSkSEntity>.AddBuff<T>(IIcSkSEntity entity, T buff)
        {
            throw new NotImplementedException();
        }

        bool IIcSkSEntityManager<IIcSkSEntity>.RemoveBuff<T>(IIcSkSEntity entity, T buff)
        {
            throw new NotImplementedException();
        }

        bool IIcSkSEntityManager<IIcSkSEntity>.HasBuff<T>(IIcSkSEntity entity, T buff)
        {
            throw new NotImplementedException();
        }

        void IStructIcSkSEntityManager<IIcSkSEntity>.AddBuff<T>(IIcSkSEntity entity, T buff)
        {
            AddBuff((IcSkSEntity)entity,buff);
        }

        bool IStructIcSkSEntityManager<IIcSkSEntity>.RemoveBuff<T>(IIcSkSEntity entity, T buff)
        {
            return RemoveBuff((IcSkSEntity)entity,buff);
        }

        bool IStructIcSkSEntityManager<IIcSkSEntity>.HasBuff<T>(IIcSkSEntity entity, T buff)
        {
            return RemoveBuff((IcSkSEntity)entity,buff);
        }

        void IIcSkSEntityManager<IcSkSEntity>.AddBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IcSkSEntity>)}");
        }

        bool IIcSkSEntityManager<IcSkSEntity>.RemoveBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IcSkSEntity>)}");
        }

        bool IIcSkSEntityManager<IcSkSEntity>.HasBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<IcSkSEntity>)}");
        }

        #endregion
    }
}