using System;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
{
    public class BuffEntityManager:IStructBuffEntityManager<NewBuffManager>
    {
        private FasterList<BuffEntity> _entitys;

        
        public NewBuffManager BuffManager { get; }
        
        public BuffEntityManager(NewBuffManager buffManager)
        {
            BuffManager = buffManager;
            _entitys = new FasterList<BuffEntity>();
        }

        private int _id;
        
        public BuffEntity CreateEntity()
        {
            ++_id;

            return CreateEntity(_id);
        }

        public BuffEntity CreateEntity(int id)
        {
            BuffEntity entity = id;
            
            BuffManager.AddEntity(entity);
            
            return entity;
        }

        public bool DestroyEntity(int id)
        {
            return DestroyEntity((BuffEntity) id);
        }

        public bool DestroyEntity(BuffEntity entity)
        {
            if (!_checkEntity(entity))
            {
                return false;
            }
            
            BuffManager.RemoveEntity(entity);

            return true;
        }

        private bool _checkEntity(BuffEntity entity)
        {
            return _entitys.Contains(entity);
        }

        public void Update()
        {
            BuffManager.Update();
        }

        public void AddBuff<T>(BuffEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            BuffManager.AddBuff(entity,buff);
        }

        public bool RemoveBuff<T>(BuffEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            return BuffManager.RemoveBuff(entity, buff);
        }

        public bool HasBuff<T>(BuffEntity entity, T buff) where T :struct, IBuffDataComponent
        {
            return BuffManager.HasBuff(entity, buff);
        }

        #region Cover

        void IBuffEntityManager<NewBuffManager>.AddBuff<T>(BuffEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffEntityManager<NewBuffManager>)}");
        }

        bool IBuffEntityManager<NewBuffManager>.RemoveBuff<T>(BuffEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffEntityManager<NewBuffManager>)}");
        }

        bool IBuffEntityManager<NewBuffManager>.HasBuff<T>(BuffEntity entity, T buff)
        {
            throw new NotImplementedException($"Type is {nameof(IStructBuffEntityManager<NewBuffManager>)}");
        }

        #endregion
    }
}