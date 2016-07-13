using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FakeServer {

	public Dictionary<string,string> RecieveCommand(string command, int id)
    {
        switch(command)
        {
            case "accountBan":
                return getAccountBan(id);
            case "accountInfo":
                return getAccountInfo(id);
            case "message":
                return getMessage(id);
            case "playerBlock":
                return getNumberOfBlocks(id);
            default:
                Debug.LogError("unhandled command: " + command + ", id: " + id);
                return getAccountBan(id);
        }
    }

    public List<string> RecieveCommand(string command)
    {
        switch(command)
        {
            case "FlaggedUsers":
                return new List<string> { "0", "1", "3" };
        }
        return new List<string>();
    }

    public string RetrieveSingleData(string command, int id)
    {
        switch (command)
        {
            case "name":
                return "Henri Hill";
        }
        return " ";
    }

    private Dictionary<string,string> getAccountBan(int id)
    {
        Dictionary<string, string> toRet = new Dictionary<string, string>();
        toRet.Add("accountId", id.ToString());
        toRet.Add("startDate", "03/07/2015");
        toRet.Add("endDate", "03/07/2016");
        toRet.Add("canceledDated", "05/05/2016");
        toRet.Add("reason", "alcholic, vulgar, aggressive to people who use charcoal");
        toRet.Add("banStatus", "banned");
        toRet.Add("nbrTemporaryBan", "3");
        toRet.Add("lastUpdate", "03/07/2015");
        return new Dictionary<string, string>();
    }

    private Dictionary<string, string> getAccountInfo(int id)
    {
        Dictionary<string, string> toRet = new Dictionary<string, string>();
        toRet.Add("accountId", id.ToString());
        toRet.Add("gameExternalId", "3e-599");
        toRet.Add("firstName", "Henri");
        toRet.Add("lastName", "Hill");
        toRet.Add("gender", "male");
        toRet.Add("birthdayDate", "03/07/1978");
        toRet.Add("tags", "propane,buh-bobby, mm thats a clean burn, I tell you what");
        toRet.Add("about", "Looking for someone to talk about the clean burn of propane");
        toRet.Add("likes", "6");
        toRet.Add("latitude", "0");
        toRet.Add("longitutde", "0");
        toRet.Add("isSearchIncludeMale", "true");
        toRet.Add("isSearchIncludeFemale", "true");
        toRet.Add("isSearchIncludeCustom", "true");
        toRet.Add("searchMinAge", "42");
        toRet.Add("searchMaxAge", "92");
        toRet.Add("personalityQuestionCursor", "0");
        toRet.Add("extrovert", "5");
        toRet.Add("agreeableScore", "2");
        toRet.Add("responsibleScore", "10");
        toRet.Add("emotionalScore", "10");
        toRet.Add("adventurousScore", "0");
        toRet.Add("numberTimesReport", "0");
        toRet.Add("isPersonalityVisible", "true");
        toRet.Add("isDiscoverable", "true");
        toRet.Add("vipStatusExpirationDateTime", "05/07/2016");
        toRet.Add("searchIncludeMale", "true");
        toRet.Add("searchIncludeFemale", "true");
        toRet.Add("searchIncludeCustom", "true");
        toRet.Add("personalityVisible", "true");
        toRet.Add("discoverable", "true");
        return toRet;
    }

    private Dictionary<string, string> getMessage(int id)
    {
        Dictionary<string, string> toRet = new Dictionary<string, string>();
        toRet.Add("id", id.ToString());
        toRet.Add("sendId", "0");
        toRet.Add("destId", "3");

        return new Dictionary<string, string>();
    }

    private Dictionary<string, string> getNumberOfBlocks(int id)
    {
        Dictionary<string, string> toRet = new Dictionary<string, string>();
        toRet.Add("nmbrOfBlocks", "4");
        return toRet;
    }
}
