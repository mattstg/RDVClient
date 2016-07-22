using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FakeServer {

    public string GetAllBlocksAgainstUser(string accountID)
    {
        return "";
    }

    public List<string> GetFlaggedUsers(string command)
    {
        switch(command)
        {
            case "FlaggedUsers":
                return new List<string>
                { "b7669bdb-5b6a-4dbb-bfef-38e6416bedd8"    //Rick Bushakstein
                , "073c789b-1ba0-4d19-8f8e-49e0125a2721"    //Dick Zamoreman
                , "def540d7-44e5-49ce-8d93-cb9ab4af75c2" }; //Caroal Goldmanman
        }
        return new List<string>();
    }

    public string GetNameOfAccountID(string accountID)
    {
        switch(accountID)
        {
            case "b7669bdb-5b6a-4dbb-bfef-38e6416bedd8":
                return "Rick Bushakstein";
            case "073c789b-1ba0-4d19-8f8e-49e0125a2721":
                return "Dick Zamoreman";
            case "def540d7-44e5-49ce-8d93-cb9ab4af75c2":
                return "Caroal Goldmanman";
        }
        return "invalid";
    }
}
