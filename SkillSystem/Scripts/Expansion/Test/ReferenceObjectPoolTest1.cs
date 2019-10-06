using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Utils;
using NUnit.Framework;
using UnityEngine.Profiling;
using Debug = UnityEngine.Debug;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    class testObj
    {
        
    }
    /// <summary>
    /// 对象创建及归还
    /// </summary>
    public class ReferenceObjectPoolTest1
    {
        private ReferenceObjectPool _pool;
        private List<testObj> _objs;
        private long _startMemory;
        private long _endMemory;
        private Stopwatch _stop;

        [SetUp]
        public void Init()
        {
            _pool = new ReferenceObjectPool(maxCount: 20000);
            _objs = new List<testObj>();
            _pool.RecedeCache = true;
            _stop = new Stopwatch();
            _startMemory = GC.GetTotalMemory(true);
            _stop.Restart();
        }

        [TearDown]
        public void End()
        {
            Debug.Log($"耗时:{_stop.Elapsed}");
            Debug.Log($"{_startMemory} and {_endMemory} = {(_endMemory - _startMemory)}");
        }

        /// <summary>
        /// 对象创建
        /// </summary>
        [Test]
        public void 创建500()
        {
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _objs.Add(testObj);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(true);
            Assert.GreaterOrEqual(_pool[typeof(testObj),true].Count,500);
        } 
        
        
        /// <summary>
        /// 对象归还
        /// </summary>
        [Test]
        public void 创建500归还200()
        {
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _objs.Add(testObj);
            }
            
            for (int i = 0; i < 200; i++)
            {
                _pool.Recede(_objs[i]);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(true);
            Assert.GreaterOrEqual(_pool[typeof(testObj),true].Count,300);
            Assert.GreaterOrEqual(_pool[typeof(testObj),false].Count,200);
        } 
        
        [Test]
        public void 一边创建一边归还10001()
        {
            for (int i = 0; i < 10001; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _pool.Recede(testObj);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(true);
            Assert.GreaterOrEqual(_pool[typeof(testObj)].Count, 1);
        } 
        
        [Test]
        public async void 创建10001()
        {
            for (int i = 0; i < 10001; i++)
            {
                var testObj = new testObj();
                _objs.Add(testObj);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(true);
            Assert.GreaterOrEqual(_objs.Count,10001);
        } 
        
        [Test]
        public async void 创建10001_Pool()
        {
            var type = typeof(testObj);
            for (int i = 0; i < 10001; i++)
            {
                _pool.GetObject(type);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(false);
            Assert.GreaterOrEqual(_pool.GetTypeCacheCount(type),10001);
        } 
        
        [Test]
        public async void 创建100()
        {
            for (int i = 0; i < 100; i++)
            {
                var testObj = new testObj();
                _objs.Add(testObj);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(true);
            Assert.GreaterOrEqual(_objs.Count,100);
        } 
        
        [Test]
        public async void 创建100_Pool()
        {
            var type = typeof(testObj);
            for (int i = 0; i < 100; i++)
            {
                _pool.GetObject(type);
            }
            _stop.Stop();
            _endMemory = GC.GetTotalMemory(false);
            Assert.GreaterOrEqual(_pool.GetTypeCacheCount(type),100);
        } 
    }
}