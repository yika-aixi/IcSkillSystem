using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Camera/Get/Main")]
    public class GetMainCameraNode : AGetCameraNode
    {
        private Camera _mainCamera;
        
        protected override Camera GetCamera()
        {
            if (!_mainCamera)
            {
                _mainCamera = Camera.main;
            }
            
            return _mainCamera;
        }

        protected override string GetCameraTooltip()
        {
            return Camera ? $"Main Camera: {Camera.name}" : "Main Camera";
        }
    }
}