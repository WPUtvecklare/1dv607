using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace application
{
  class Storage
  {
    public void saveToJson(ReadOnlyCollection<Member> memberList)
    {
      File.WriteAllText("AppData/memberList.json", JsonConvert.SerializeObject(memberList, Formatting.Indented));
    }

    public List<Member> loadUsers()
    {
      string json = File.ReadAllText("AppData/memberList.json");
      List<Member> members = JsonConvert.DeserializeObject<List<Member>>(json);
      return members;
    }
  }
}