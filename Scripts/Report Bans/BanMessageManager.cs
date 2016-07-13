using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanMessageManager : MonoBehaviour {

    //Controls the MessagePreivew panel
    public void Initialize(int id)
    {
        LoadAllMessagePreviewPanels(id);
    }

    public void LoadAllMessagePreviewPanels(int id)
    {
        ClearAllMessagePreviewPanels();
        List<FlaggedInfo> allFlaggedInfos = GV.accountRetriever.GetAllFlaggedInfos(id);
        foreach (FlaggedInfo fi in allFlaggedInfos)
            LoadMessagePreviewPanel(fi);
    }

    void LoadMessagePreviewPanel(FlaggedInfo flaggedInfo)
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/MessagePreview")) as GameObject;
        go.transform.SetParent(GV.reportBanRefs.messageGrid);
        go.GetComponent<MessagePreview>().Initialize(flaggedInfo);
        
    }

    void ClearAllMessagePreviewPanels()
    {
        foreach (Transform t in GV.reportBanRefs.messageGrid)
            if (t != GV.reportBanRefs.messageGrid)
                Destroy(t.gameObject);
    }
	
}
