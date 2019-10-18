using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTextCore
{
    public class Memory
    {
        public Stack<int> MemStack { private set; get; }
        public Dictionary<string, int> Registers { private set; get; }
        public Dictionary<string, object> Variables { private set; get; }

        public Memory()
        {
            MemStack = new Stack<int>();
            Registers.Add("RA", default);
            Registers.Add("RB", default);
            Registers.Add("RC", default);
            Registers.Add("RD", default);
            Registers.Add("RE", default);
            Registers.Add("RF", default);
            Variables = new Dictionary<string, object>();
        }

        public void Clear()
        {
            MemStack.Clear();
            Registers["RA"] = default;
            Registers["RB"] = default;
            Registers["RC"] = default;
            Registers["RD"] = default;
            Registers["RE"] = default;
            Registers["RF"] = default;
            Variables.Clear();
        }
    }
}
