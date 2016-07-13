using UnityEngine;
using System.Collections;

public class GV {

    public enum CurrentPanel { Empty, Message, Profile }

    public static MainMenuUILinks mainMenuUILinks;
    public static ReportBanUILinks reportBanUILinks;
    public static AccountRetriever accountRetriever = new AccountRetriever();
    public static FakeServer fakeServer = new FakeServer();

    public static void DeleteChildren(Transform t)
    {
        foreach (Transform _t in t)
            if (_t != t)
                MonoBehaviour.Destroy(_t.gameObject);

    }
	
}

