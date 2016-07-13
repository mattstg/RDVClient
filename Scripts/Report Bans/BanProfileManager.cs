using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanProfileManager : MonoBehaviour {

	public void Initialize(int id)
    {
        LoadAllDataSlots(id);
    }

    private void LoadAllDataSlots(int id)
    {
        ClearAllDataSlots();
        Dictionary<string, string> dict = GV.accountRetriever.GetAccountInfo(id);
        foreach (KeyValuePair<string, string> kv in dict)
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/DataSlot")) as GameObject;
            go.GetComponent<DataSlot>().Initialize(kv.Key, kv.Value);
            go.transform.SetParent(GV.reportBanUILinks.profileGrid);
        }
    }

    private void ClearAllDataSlots()
    {
        GV.DeleteChildren(GV.reportBanUILinks.profileGrid);
    }
}
