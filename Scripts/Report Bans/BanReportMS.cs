using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanReportMS : MonoBehaviour {

    // Use this for initialization
    GV.CurrentPanel currentActivePanel = GV.CurrentPanel.Empty;
    int selectedID = -1;

	void Start () {
        RefreshUserList();
	}

    public void RefreshUserList()
    {
        ClearUserList();
        LoadAllFlaggedUsers();
    }

    void LoadAllFlaggedUsers()
    {
        List<int> flaggedUsers = GV.accountRetriever.RetrieveFlaggedAccounts();
        foreach (int userid in flaggedUsers)
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/UserButton")) as GameObject;
            go.transform.SetParent(GV.reportBanRefs.userListGrid);
            go.GetComponent<UserSlot>().Initialize(userid);
        }
    }

    void ClearUserList()
    {
        foreach(Transform t in GV.reportBanRefs.userListGrid)
        {
            if(t != GV.reportBanRefs.userListGrid)
                Destroy(t.gameObject);
        }
    }

    public void ExitButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");        
    }

    void CloseAllPanels()
    {
        GV.reportBanRefs.messageGrid.gameObject.SetActive(false);
        GV.reportBanRefs.profileGrid.gameObject.SetActive(false);
    }

    public void OpenMessagePanelPressed()
    {
        CloseAllPanels();
        if (selectedID != -1)
        {
            GV.reportBanRefs.messageGrid.gameObject.SetActive(true);
            GV.reportBanRefs.messageGrid.GetComponent<BanMessageManager>().Initialize(selectedID);
        }

    }

    public void OpenProfilePanelPressed()
    {
        CloseAllPanels();
        if (selectedID != -1)
        {
            GV.reportBanRefs.profileGrid.gameObject.SetActive(true);
            GV.reportBanRefs.profileGrid.GetComponent<BanProfileManager>().Initialize(selectedID);
        }
    }

    public void UserSelected(int userID)
    {
        selectedID = userID;
        Debug.Log("msg: " + selectedID);
        OpenMessagePanelPressed();
    }
     

}
