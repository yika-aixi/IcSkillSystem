//Create: Icarus
//ヾ(•ω•`)o
//2020-07-05 01:29
//CabinIcarus.IcSkillSystem.xNodeIc

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NPBehave;
using UnityEngine;

[assembly: InternalsVisibleTo("CabinIcarus.IcSkillSystem.xNodeIc.Editor")]
namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    internal class ClockUpdate : MonoBehaviour
    {
        private List<Clock> _clocks;

        public int ClockCount => _clocks.Count;
        
        private void Awake()
        {
            _clocks = new List<Clock>();
        }

        private void Update()
        {
            foreach (var clock in _clocks)
            {
                clock?.Update(Time.deltaTime);
            }
        }

        public void AddClock(Clock clock)
        {
            _clocks.Add(clock);
        }
    }
}