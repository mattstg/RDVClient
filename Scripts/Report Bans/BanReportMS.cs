using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BanReportMS : MonoBehaviour {

    // Use this for initialization
    GV.BanReportMode activeMode = GV.BanReportMode.UpForReview;
    string selectedID = "";

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
        List<string> flaggedUsers = GV.accountRetriever.RetrieveFlaggedAccounts();
        foreach (string accountID in flaggedUsers)
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/UserButton")) as GameObject;
            go.transform.SetParent(GV.reportBanUILinks.userListGrid);
            go.GetComponent<UserSlot>().Initialize(accountID,GV.accountRetriever.GetAccountName(accountID));
        }
    }

    void LoadAllJailedUsers()
    {
        List<string> jailedUsers = GV.accountRetriever.RetrieveJailedAccounts();
        foreach (string accountID in jailedUsers)
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/UserButton")) as GameObject;
            go.transform.SetParent(GV.reportBanUILinks.userListGrid);
            go.GetComponent<UserSlot>().Initialize(accountID, GV.accountRetriever.GetAccountName(accountID));
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
        GV.reportBanUILinks.reportGrid.gameObject.SetActive(false);
        GV.reportBanUILinks.profileGrid.gameObject.SetActive(false);
        GV.reportBanUILinks.pictureManager.gameObject.SetActive(false);
    }

    public void OpenReportListPanel()
    {
        CloseAllPanels();
        GV.reportBanUILinks.reportGrid.gameObject.SetActive(true);
        GV.reportBanUILinks.reportGrid.GetComponent<ReportManager>().Initialize(selectedID);
    }

    public void OpenProfilePanelPressed()
    {
        CloseAllPanels();
        GV.reportBanUILinks.profileGrid.gameObject.SetActive(true);
        GV.reportBanUILinks.profileGrid.GetComponent<ProfileManager>().Initialize(selectedID);
    }

    public void UserSelected(string userID)
    {
        selectedID = userID;
        if (selectedID != "")
        {
           GV.reportBanUILinks.navigationBar.gameObject.SetActive(true);
           OpenReportListPanel();
           GV.reportBanUILinks.headerText.text = GV.accountRetriever.GetAccountName(selectedID) + " (" + selectedID + ")";
        }
        else
        {
            CloseAllPanels();
            GV.reportBanUILinks.navigationBar.gameObject.SetActive(false);
        }
    }

    public void BanForgivePopupPressed()
    {
        GV.reportBanUILinks.banForgivePopup.gameObject.SetActive(true);
        GV.reportBanUILinks.banForgivePopup.GetComponent<BanForgivePopup>().Initialize(selectedID);

    }

    public void SearchButtonPressed()
    {
        string searchRequest = GV.reportBanUILinks.searchBarInput.text;
    }

    public void OpenPicturePanel()
    {
        CloseAllPanels();
        GV.reportBanUILinks.pictureManager.gameObject.SetActive(true);
        GV.reportBanUILinks.pictureManager.Initialize(selectedID);
    }

    public void LoadUpForReviewMode()
    {
        activeMode = GV.BanReportMode.UpForReview;
        GV.reportBanUILinks.jailImg.gameObject.SetActive(false);
        //GV.reportBanUILinks.banForgiveButton.gameObject.SetActive(true);
        GV.reportBanUILinks.jailModeButton.GetComponent<Image>().color = Color.white;
        GV.reportBanUILinks.reviewModeButton.GetComponent<Image>().color = Color.grey;
    }

    public void LoadJailedMode()
    {
        activeMode = GV.BanReportMode.JailMode;
        GV.reportBanUILinks.jailImg.gameObject.SetActive(true);
        //GV.reportBanUILinks.banForgiveButton.gameObject.SetActive(false);
        GV.reportBanUILinks.jailModeButton.GetComponent<Image>().color = Color.grey;
        GV.reportBanUILinks.reviewModeButton.GetComponent<Image>().color = Color.white;
    }

}
