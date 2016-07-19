using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReportManager : MonoBehaviour {

    //Controls the MessagePreivew panel
    public void Initialize(string id)
    {
        LoadAllReportSlots(id);
    }

    public void LoadAllReportSlots(string id)
    {
        ClearAllBlockSlots();
        List<FlaggedInfo> allFlaggedInfos =  GV.accountRetriever.GetReportsOnIdJSON(id);
        foreach (FlaggedInfo fi in allFlaggedInfos)
            LoadReportSlot(fi);
    }

    void LoadReportSlot(FlaggedInfo flaggedInfo)
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/BlockSlot")) as GameObject;
        go.transform.SetParent(GV.reportBanUILinks.reportGrid);
        go.GetComponent<BlockSlotGUI>().Initialize(flaggedInfo);
    }

    void ClearAllBlockSlots()
    {
        GV.DeleteChildren(GV.reportBanUILinks.reportGrid);
    }
	
}
