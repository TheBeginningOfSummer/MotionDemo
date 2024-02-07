using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services
{
    public class FileService
    {

    }

    /// <summary>
    /// 静态Json管理类
    /// </summary>
    public class JsonManager
    {
        public static void SaveJson(string path, string fileName, object data)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "/" + fileName;
            string jsonString = System.Text.Json.JsonSerializer.Serialize(data);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
            FileStream file = new FileStream(path, FileMode.Create);
            file.Write(jsonBytes, 0, jsonBytes.Length);//整块写入
            file.Flush();
            file.Close();
        }

        public static T ReadJson<T>(string path, string fileName)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "/" + fileName;
            if (File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader stream = new StreamReader(file);
                T jsonData = System.Text.Json.JsonSerializer.Deserialize<T>(stream.ReadToEnd());
                file.Flush();
                file.Close();
                //T jsonData = JsonMapper.ToObject<T>(File.ReadAllText(path));
                return jsonData;
            }
            return default;
        }

        public static void SaveJsonString(string path, string fileName, object data)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "/" + fileName;
            string jsonString = JsonMapper.ToJson(data);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
            FileStream file = new FileStream(path, FileMode.Create);
            file.Write(jsonBytes, 0, jsonBytes.Length);//整块写入
            file.Flush();
            file.Close();
        }

        public static T ReadJsonString<T>(string path, string fileName)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "/" + fileName;
                if (File.Exists(path))
                {
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader stream = new StreamReader(file);
                    T jsonData = JsonMapper.ToObject<T>(stream.ReadToEnd());
                    file.Flush();
                    file.Close();
                    //T jsonData = JsonMapper.ToObject<T>(File.ReadAllText(path));
                    return jsonData;
                }
            }
            catch (Exception)
            {

            }
            return default;
        }

        public static JsonData ReadSimpleJsonString(string path)
        {
            JsonData jsonData = JsonMapper.ToObject(File.ReadAllText(path));
            return jsonData;
        }
    }
    /// <summary>
    /// 文件配置存储类
    /// </summary>
    public class KeyValueManager
    {
        public string FileName { get; set; }
        public string ConfigurationPath { get; set; }
        public Dictionary<string, string> KeyValueList;

        public KeyValueManager(string fileName, string path, params string[] keyValues)
        {
            FileName = fileName;
            ConfigurationPath = path;
            KeyValueList = JsonManager.ReadJsonString<Dictionary<string, string>>(ConfigurationPath, FileName);
            if (KeyValueList == null) KeyValueList = new Dictionary<string, string>();
            if (keyValues.Length % 2 == 0 && keyValues.Length != 0)
            {
                for (int i = 0; i < keyValues.Length; i += 2)
                {
                    if (!KeyValueList.ContainsKey(keyValues[i]))
                    {
                        KeyValueList.Add(keyValues[i], keyValues[i + 1]);
                        JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
                    }
                }
            }
        }

        public void Add(string key, string value)
        {
            KeyValueList.Add(key, value);
            JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
        }

        public void Remove(string key)
        {
            KeyValueList.Remove(key);
            JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
        }

        public void Change(string key, string value)
        {
            if (KeyValueList.ContainsKey(key))
            {
                KeyValueList[key] = value;
                JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
            }
            else
            {
                Add(key, value);
            }
        }

        public string Load(string key)
        {
            try
            {
                if (KeyValueList.ContainsKey(key))
                    return KeyValueList[key];
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public T Load<T>(string key)
        {
            string value = Load(key);
            if (value == "")
            {
                return default;
            }
            else
            {
                T result = (T)Convert.ChangeType(value, typeof(T));
                return result;
            }
        }

        public string Load(string key, string defaultValue)
        {
            if (!KeyValueList.ContainsKey(key))
                Change(key, defaultValue);
            return KeyValueList[key];
        }

        
    }
}
