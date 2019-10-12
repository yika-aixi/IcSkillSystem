using System;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
{
    public class IcSkSEntityManager:IStructIcSkSEntityManager<BuffManager>
    {
        private FasterList<IcSkSEntity> _entitys;

        
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

        #region Cover

        void IIcSkSEntityManager<BuffManager>.AddBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<BuffManager>)}");
        }

        bool IIcSkSEntityManager<BuffManager>.RemoveBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<BuffManager>)}");
        }

        bool IIcSkSEntityManager<BuffManager>.HasBuff<T>(IcSkSEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructIcSkSEntityManager<BuffManager>)}");
        }

        #endregion
    }
}