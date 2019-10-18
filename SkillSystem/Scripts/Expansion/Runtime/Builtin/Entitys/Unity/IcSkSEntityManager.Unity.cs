using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using UnityEngine;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys
{
    public partial class IcSkSEntityManager
    {
//        private Dictionary<IcSkSEntity, GameObject> _entityBindMap;
        
        /// <summary>
        /// unity物体绑定,绑定成功将会给go添加一个 <see cref="EntityBindComponent"/>组件
        /// </summary>
        /// <param name="go"></param>
        /// <param name="entity"></param>
        /// <returns>实体不存在返回false,存在将被覆盖</returns>
        public bool BindEntity(GameObject go, IcSkSEntity entity)
        {
            if (!_checkEntity(entity))
            {
                return false;
            }

//            if (!_entityBindMap.ContainsKey(entity))
//            {
//                _entityBindMap.Add(entity,go);
//            }

            var entityBind = go.GetComponent<EntityBindComponent>();
            
            if (!entityBind)
            {
                entityBind = go.AddComponent<EntityBindComponent>();
            }

            entityBind.Entity = entity;

            return true;
        }

        /// <summary>
        /// 创建实体并绑定
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public IcSkSEntity CreateEntityAndBind(GameObject go)
        {
            var entity = CreateEntity();

            if (entity.ID == -1)
            {
                return entity;
            }
            
            BindEntity(go, entity);
            
            return entity;
        }

        /// <summary>
        /// 创建实体并绑定
        /// </summary>
        /// <param name="go"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IcSkSEntity CreateEntityAndBind(GameObject go,int id)
        {
            var entity = CreateEntity(id);

            if (entity.ID == -1)
            {
                return entity;
            }
            
            BindEntity(go, entity);
            
            return entity;
        }
    }
    
    public class EntityBindComponent : MonoBehaviour
    {
        public IcSkSEntity Entity;
    }
}