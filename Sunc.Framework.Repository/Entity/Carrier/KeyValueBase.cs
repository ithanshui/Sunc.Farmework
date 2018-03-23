using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Entity.Carrier
{
    public class KeyValueBase <Key,Value>: EntityBase
    {
        public Key key { set; get; }
        public Value value { set; get; }
    }
}
