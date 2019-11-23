using System;
using CabinIcarus.IcSkillSystem.Expansion.Builtin.Component;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Entitys;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    struct TestBuff1:IDamageBuff,IEquatable<TestBuff1>
    {
        public float Value { get; set; }
        public int Type { get; set; }

        public bool Equals(TestBuff1 other)
        {
            return Value.Equals(other.Value) && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            return obj is TestBuff1 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Type;
            }
        }

        public override string ToString()
        {
            return $"{Value} _ {Type}";
        }

        public TestBuff1(float value, int type)
        {
            Value = value;
            Type = type;
            Entity = -1;
        }

        public IcSkSEntity Entity { get; set; }
    }
    
    struct TestBuff2:IMechanicBuff,IEquatable<TestBuff2>
    {
        public float Value { get; set; }
        public MechanicsType MechanicsType { get; set; }
        
        public TestBuff2(float value, MechanicsType mechanicsType)
        {
            Value = value;
            MechanicsType = mechanicsType;
        }

        public bool Equals(TestBuff2 other)
        {
            return Value.Equals(other.Value) && MechanicsType == other.MechanicsType;
        }

        public override bool Equals(object obj)
        {
            return obj is TestBuff2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Value.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) MechanicsType;
                return hashCode;
            }
        }
    }
    
    public class BuffManagerTestMonoBehaviour : MonoBehaviour
    {
        public int EntityCount;

        private int _maxEntityId;

        private IcSkSEntityManager _entityManager;

        private void Awake()
        {
            _entityManager = new IcSkSEntityManager(new BuffManager_Struct());
            _maxEntityId = EntityCount;
        }

        private void Start()
        {
            for (int i = 0; i < EntityCount; i++)
            {
                var id = i + 1;
                
                var entity = _entityManager.CreateEntity(id);
                
                GameObject go = new GameObject($"Entity ID:{id}");

                var link = go.AddComponent<BuffEntityLinkComponent>();
                link.Init(_entityManager,entity);
            }
        }

        public bool Debug;
        public bool IsAdd;
        
        private void Update()
        {
            if (Debug)
            {
                if (IsAdd)
                {
                    _addBuff(Random.Range(1, _maxEntityId + 1));
                }
                else
                {
                    _removeBuff(Random.Range(1, _maxEntityId + 1));
                }
            }
        }

        private void _removeBuff(IcSkSEntity entity)
        {
            var count = _entityManager.BuffManager.GetBuffCount<TestBuff1>(entity);
            var value = count % 2;
            if (value == 0)
            {
                _entityManager.RemoveBuff(entity, new TestBuff1(count, count));
            }
            else
            {
                count = _entityManager.BuffManager.GetBuffCount<TestBuff2>(entity);
                _entityManager.RemoveBuff(entity, new TestBuff2(count, MechanicsType.Health));
            }

        }

        private void _addBuff(IcSkSEntity entity)
        {
            var count = _entityManager.BuffManager.GetBuffCount<TestBuff1>(entity);
            var value = count % 2;
            if (value == 0)
            {
                _entityManager.AddBuff(entity, new TestBuff1(count+1, count+1));
            }
            else
            {
                count = _entityManager.BuffManager.GetBuffCount<TestBuff2>(entity);
                _entityManager.AddBuff(entity, new TestBuff2(count+1, MechanicsType.Health));
            }
        }

        [ContextMenu("Test Set 0")]
        private void _testSet()
        {
            _entityManager.BuffManager.SetBuffData(1,new TestBuff1(100,100), 0);
        }
    }
}