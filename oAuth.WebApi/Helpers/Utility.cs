using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace oAuth.WebAPI.BL.Helpers
{
    public class Utility
    {

        public static byte[] ToByteArray(object source)
            {
                var formatter = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    formatter.Serialize(stream, source);
                    return stream.ToArray();
                }
            }

        
    }
}