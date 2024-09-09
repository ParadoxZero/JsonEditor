using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebInfoEditor.Model
{
    internal class AzureJsonFile
    {
        private readonly string _url;
        private readonly SecureString _token;
        private dynamic _jsonObject;
        internal AzureJsonFile(string url, SecureString token)
        {
            _url = url;
            _token = token;
        }

        public async void LoadJson()
        {
            string testJson = "{'test':'testVal','other':'otherval','list':[]}";
            _jsonObject = JsonSerializer.Deserialize<dynamic>(testJson);
            // TODO: Fetch actual from internet
        }

        public dynamic GetRoot() { return _jsonObject; }

        public static IEnumerable<JsonNode> GetNodes(dynamic jsonObject)
        {
            foreach (var node in jsonObject)
            {
                JsonNode jsonNode = new();
                if (node is int intval)
                {
                    jsonNode.intVal = intval;
                    jsonNode.type = JsonNode.Type.Number;
                }
                else if (node is string str)
                {
                    jsonNode.strVal = str;
                    jsonNode.type = JsonNode.Type.String;
                }
                else if (node is bool boolval)
                {
                    jsonNode.bVal = boolval;
                    jsonNode.type = JsonNode.Type.Boolean;
                }
                else if (node is IEnumerable<dynamic> list)
                {
                    jsonNode.list = list;
                    jsonNode.type = JsonNode.Type.List;
                }
                else
                {
                    jsonNode.objectVal = node;
                    jsonNode.type = JsonNode.Type.Object;
                }
                yield return jsonNode;
            }
        }
    }
}
