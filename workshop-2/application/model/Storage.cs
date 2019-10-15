using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace application
{
    class Storage
    {
        public void saveToJson<T>(ReadOnlyCollection<T> memberList)
        {
            File.WriteAllText("AppData/memberList.json", JsonConvert.SerializeObject(memberList, Formatting.Indented));
        }

        public List<T> loadUsers<T>()
        {
            string json = File.ReadAllText("AppData/memberList.json");
            List<T> members = JsonConvert.DeserializeObject<List<T>>(json);
            return members;
        }
    }
}