using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Retrieves info, converts JSON into required type (dictionary mostly)
public class AccountRetriever  {

    public List<int> RetrieveFlaggedAccounts()
    {
        List<int> toRet = new List<int>();
        List<string> json = GV.fakeServer.RecieveCommand("FlaggedUsers");

        foreach (string userid in json)
            toRet.Add(int.Parse(userid));

        return toRet;
    }

    public Dictionary<string,string> GetAccountInfo(int id)
    {
        return GV.fakeServer.RecieveCommand("accountInfo",id);
    }

    public string RetrieveConvo(int fromID, int toID, Date date)
    {
        return "Henri Hill: Hello there! '\n' CharcoalLover69: Hi!  '\n'   Henri Hill: ....  '\n'    Henri Hill: Wanna hear about what burns clean I'll tell you whut <Descriptive text of genocide of CharcoalLover69's racial ethenticity>";
    }

    //Returns all flag infos against id
    public List<FlaggedInfo> GetAllFlaggedInfos(int id)
    {
        List<FlaggedInfo> toRet = new List<FlaggedInfo>();
        toRet.Add(new FlaggedInfo(new Date(10, 10, 1988), 1, 0, "Offensive"));
        toRet.Add(new FlaggedInfo(new Date(10, 10, 2011), 2, 0, "Racist"));
        return toRet;
    }

}
