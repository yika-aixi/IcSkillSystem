using System;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public class CheckFailureException:Exception
    {
        public string CheckFunctionName { get; }

        public CheckFailureException(string checkFunctionName, string message) : base(message)
        {
            CheckFunctionName = checkFunctionName;
        }
    }
    
    public static class IcCheck
    {
        public static bool UseException = true;
        
        class Trace
        {
            internal static void Assert(bool assertion, string functionName,string v)
            {
#if NETFX_CORE
            System.Diagnostics.Contracts.Contract.Assert(assertion, $"Check {functionName} Failure. Message:{v}");
#else
                System.Diagnostics.Trace.Assert(assertion, $"Check {functionName} Failure. Message:{v}");
#endif      
            }
        }

        public static void True(bool value)
        {
            True(value,string.Empty);
        }
        
        public static void True(bool value, string message)
        {
            if (UseException)
            {
                if (!value)
                    throw new CheckFailureException(nameof(True), message);
            }
            
            Trace.Assert(value,nameof(True), message);
        }
    }
}