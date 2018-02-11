using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Base_Defence
{
    static class Helpers
    {
        static public Assembly _assembly = Assembly.GetExecutingAssembly();

        public static Stream GetResource(string name)
        {
            return _assembly.GetManifestResourceStream("Base_Defence." + name);
        }
    }
}
