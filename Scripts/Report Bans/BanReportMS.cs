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
            go.transform.SetParent(GV.reportBanUILinks.userListGrid);
            go.GetComponent<UserSlot>().Initialize(userid);
        }
    }

    void ClearUserList()
    {
        foreach(Transform t in GV.reportBanUILinks.userListGrid)
        {
            if(t != GV.reportBanUILinks.userListGrid)
                Destroy(t.gameObject);
        }
    }

    public void ExitButtonPressed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");        
    }

    void CloseAllPanels()
    {
        GV.reportBanUILinks.messageGrid.gameObject.SetActive(false);
        GV.reportBanUILinks.profileGrid.gameObject.SetActive(false);
    }

    public void OpenMessagePanelPressed()
    {
        CloseAllPanels();
        if (selectedID != -1)
        {
            GV.reportBanUILinks.messageGrid.gameObject.SetActive(true);
            GV.reportBanUILinks.messageGrid.GetComponent<BanBlockSlotManager>().Initialize(selectedID);
        }

    }

    public void OpenProfilePanelPressed()
    {
        CloseAllPanels();
        if (selectedID != -1)
        {
            GV.reportBanUILinks.profileGrid.gameObject.SetActive(true);
            GV.reportBanUILinks.profileGrid.GetComponent<BanProfileManager>().Initialize(selectedID);
        }
    }

    public void UserSelected(int userID)
    {
        selectedID = userID;
        OpenMessagePanelPressed();
    }

    public void BanForgivePopupPressed()
    {
        GV.reportBanUILinks.banForgivePopup.gameObject.SetActive(true);
        GV.reportBanUILinks.banForgivePopup.GetComponent<BanForgivePopup>().Initialize(selectedID);
    }

}
