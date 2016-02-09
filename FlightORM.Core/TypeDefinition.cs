using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FlightORM.Core
{
    [DataContract]
    public class TypeDefinition : StoreableBase<TypeDefinition>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Type SimpleType { get; set; }
        [DataMember]
        public Dictionary<string, TypeDefinition> Properties { get; set; }
    }
}
