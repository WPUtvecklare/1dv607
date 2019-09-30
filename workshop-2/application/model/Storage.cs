using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace application
{
  class Storage
  {

    public Storage()
    {
    }

    public void saveToJson(List<Member> memberList)
    {
      File.WriteAllText("memberList.json", JsonConvert.SerializeObject(memberList, Formatting.Indented));
    }

    public List<Member> loadUsers()
    {
      string json = File.ReadAllText("memberList.json");
      List<Member> members = JsonConvert.DeserializeObject<List<Member>>(json);
      return members;
    }
  }
}