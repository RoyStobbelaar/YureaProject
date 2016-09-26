using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace XLevelEditor
{
    static class XnaSerializer
    {
        public static void Serialize<T>(string fileName, T data)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using(XmlWriter writer = XmlWriter.Create(fileName, settings))
            {
                IntermediateSerializer.Serialize<T>(writer, data, null);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            T data;

            using(FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                using(XmlReader reader = XmlReader.Create(stream))
                {
                    data = IntermediateSerializer.Deserialize<T>(reader, null);
                }
            }
            return data;
        }
    }
}
