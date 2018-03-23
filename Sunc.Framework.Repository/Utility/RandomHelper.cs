using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunc.Framework.Repository.Utility
{
    public class RandomHelper
    {
        public static int RandomNumber(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
        /// <summary>
        /// () --> 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  
        /// ("N") --> e0a953c3ee6040eaa9fae2b667060e09   
        /// ("D") --> 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  
        /// ("B") --> {734fd453-a4f8-4c5d-9c98-3fe2d7079760}  
        /// ("P") --> (ade24d16-db0f-40af-8794-1e08e2040df3)  
        /// ("X") --> {0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}  
        /// </summary>
        /// <param name="type">默认(Y) "","N","D","B","P","X"</param>
        /// <returns></returns>
        public static string RandomGuid(string type = "Y")
        {
            return Guid.NewGuid().ToString(type);
        }
    }
}
