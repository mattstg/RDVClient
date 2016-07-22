using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockSlotGUI : MonoBehaviour {

    public Date dateConvoOccured;
    public Text reporterIDText;   //text for who the message was sent to
    public Text reporterNameText;
    public Text reporterReasonText;
    public Text dateText; //the date the convo took  place
    private FlaggedInfo flaggedInfo;

    string reporterId;
    string reportedId;

    public void Initialize(FlaggedInfo fi)
    {
        reporterId = fi.reporterID;
        reportedId = fi.reportedID;
        flaggedInfo = fi;
        reporterIDText.text = fi.reporterID.ToString();
        reporterNameText.text = fi.reporterName.ToString();
        dateText.text = fi.date.ToString();
        reporterReasonText.text = fi.reason;
    }

    public void DeleteReportPressed()
    {
        GenericPopup gpu = GenericPopup.CreateGenericPopup();
        string popupText = string.Format("Reported by {0}, ID: {1}, for reason of {2}, Are you sure you want to delete this report? The users will still be blocked to each other, but it will not count as an inappripriate flag",flaggedInfo.reporterName, flaggedInfo.reporterID,flaggedInfo.reason);
        gpu.SetMainText(popupText);
        gpu.AddButton("Yes, Delete report", DeleteBlockFromServer);
        gpu.AddButton("Cancel");
    }

    public void OpenConvoPressed()
    {
        GV.reportBanUILinks.convoPopup.gameObject.SetActive(true);
        GV.reportBanUILinks.convoPopup.Initialize(flaggedInfo.reporterID, flaggedInfo.reportedID, flaggedInfo.date);
    }

    public void DeleteBlockFromServer()
    {
        GV.accountRetriever.DeleteBlockFromServer(flaggedInfo);
        GV.reportBanUILinks.banReportMS.OpenReportListPanel();
    }
}
