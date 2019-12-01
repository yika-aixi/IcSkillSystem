using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor.Utils
{
    public static class NodeEx
    {
        public static void PortRename(this Node self,NodePort port,string newName)
        {
            NodePort newPort;
            if (port.direction == NodePort.IO.Input)
            {
                newPort = self.AddDynamicInput(typeof(object), fieldName: newName,connectionType: port.connectionType,baseType: port.TypeConstraintBaseType,typeConstraint:port.typeConstraint);
            }
            else
            {
                newPort = self.AddDynamicOutput(typeof(object), fieldName: newName,connectionType: port.connectionType,typeConstraint:port.typeConstraint);
            }

            newPort.AddConnections(port);

            self.RemoveDynamicPort(port);
        }
    }
}