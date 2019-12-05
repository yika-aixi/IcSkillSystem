using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Camera/Get/Main")]
    public class GetMainCameraNode : AGetCameraNode
    {
        protected override Camera GetCamera()
        {
            return Camera.main;
        }

        protected override string GetCameraTooltip()
        {
            return Camera ? $"Main Camera: {Camera.name}" : "Main Camera";
        }
    }
}