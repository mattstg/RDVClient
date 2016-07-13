using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanBlockSlotManager : MonoBehaviour {

    //Controls the MessagePreivew panel
    public void Initialize(int id)
    {
        LoadAllBlockSlots(id);
    }

    public void LoadAllBlockSlots(int id)
    {
        ClearAllBlockSlots();
        List<FlaggedInfo> allFlaggedInfos = GV.accountRetriever.GetAllFlaggedInfos(id);
        foreach (FlaggedInfo fi in allFlaggedInfos)
            LoadBlockSlot(fi);
    }

    void LoadBlockSlot(FlaggedInfo flaggedInfo)
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/BlockSlot")) as GameObject;
        go.transform.SetParent(GV.reportBanUILinks.messageGrid);
        go.GetComponent<BlockSlotGUI>().Initialize(flaggedInfo);
    }

    void ClearAllBlockSlots()
    {
        GV.DeleteChildren(GV.reportBanUILinks.messageGrid);
    }
	
}
