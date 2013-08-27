using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

using System.Threading.Tasks;

namespace New_Dawn
{
    public static class FileUtils
    {
        public static void SerializeJson(Object obj, string file)
        {
            StreamWriter SW = null;
            try
            {
                SW = new StreamWriter(file,false);
                SW.Write(JsonConvert.SerializeObject(obj, Formatting.Indented));
                SW.Flush();
                SW.Close();
            }
            catch (Exception Ex)
            {
                //TODO: write exception to error log.
                throw;
            }
            finally
            {
                if (SW != null)
                    SW.Close();
            }
        }

        public static object DeserializeJson(Type objType, string file)
        {
            StreamReader SR = null;
            try
            {
                SR = new StreamReader(file);
                object returnObj = JsonConvert.DeserializeObject(SR.ReadToEnd(), objType);
                SR.Close();
                return returnObj;
            }
            catch (Exception Ex)
            {
                //TODO: write exception to error log.
                throw;
            }
            finally
            {
                if (SR != null)
                    SR.Close();
            }
        }

        public static void Serialize(Object obj, string file)
        {
            FileStream FS = null;
            try
            {
                FS = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                x.Serialize(FS, obj);
                FS.Flush();
                FS.Close();
            }
            catch (Exception Ex)
            {
                //TODO: write exception to error log.
                throw;
            }
            finally
            {
                if (FS != null)
                    FS.Close();
            }
        }

        public static object Deserialize(Type objType, string file)
        {
            FileStream FS = null;
            try
            {
                FS = new FileStream(file, FileMode.Open, FileAccess.Read);
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(objType);
                object returnObj = x.Deserialize(FS);
                FS.Flush();
                FS.Close();
                return returnObj;
            }
            catch (Exception Ex)
            {
                //TODO: write exception to error log.
                throw;
            }
            finally
            {
                if (FS != null)
                    FS.Close();
            }
        }
    }
}
