using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoonSharp.Interpreter;
using System;
namespace test
{
    [TestClass]
    public class MoonSharpTests
    {
        [TestMethod]
        public void generalTest()
        {
            string script = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end

		return fact(5)";

            DynValue res = Script.RunString(script);
            
            if((res.Number)!=120)
            {
                throw(new Exception());
            }
        }
    }
}
