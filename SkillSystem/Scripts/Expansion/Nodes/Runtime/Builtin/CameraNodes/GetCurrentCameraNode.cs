using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Camera/Get/Current")]
    public class GetCurrentCameraNode:AGetCameraNode
    {
        protected override Camera GetCamera()
        {
            return Camera.current;
        }
        
        protected override string GetCameraTooltip()
        {
            return Camera ? $"Current Camera: {Camera.name}" : "Current Camera";
        }
    }
}