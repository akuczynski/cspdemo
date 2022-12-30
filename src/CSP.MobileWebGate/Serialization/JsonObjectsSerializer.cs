using CSP.Core;
using CSP.Core.Command;
using CSP.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CSP.MobileWebGate.Serialization
{
    public class JsonObjectsSerializer : ISingletonDependency
    {
        private readonly IEnumerable<ICommandDeserializer> _commandDeserializers;

        private readonly IEnumerable<IQueryDeserializer> _queryDeserializers;

        public JsonObjectsSerializer(
			 IEnumerable<IQueryDeserializer> queryDeserializers,
      		 IEnumerable<ICommandDeserializer> commandDeserializers)
        {
            _commandDeserializers = commandDeserializers;
            _queryDeserializers = queryDeserializers;
        }

        public ICommand DeserializeCommand(string commandName, string jsonObject)
        {
            foreach (var commandDeserializer in _commandDeserializers)
            {
                var result = commandDeserializer.Deserialize(commandName, jsonObject);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public IQuery DeserializeQuery(string queryName, string jsonObject)
        {
            foreach (var queryDeserializer in _queryDeserializers)
            {
                var result = queryDeserializer.Deserialize(queryName, jsonObject);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
