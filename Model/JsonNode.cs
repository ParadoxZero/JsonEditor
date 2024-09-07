using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebInfoEditor.Model
{
    internal class JsonNode
    {
        public enum Type
        {
            Number,
            String,
            Boolean,
            Text,
            List,
            Object
        }

        internal Type type;
        internal bool bVal;
        internal int intVal;
        internal string strVal;
        internal IEnumerable<dynamic> list;
        internal dynamic objectVal;
    }
}
