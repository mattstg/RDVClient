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

    public void Initialize(FlaggedInfo fi)
    {
        flaggedInfo = fi;
        reporterIDText.text = fi.reporterID.ToString();
        reporterNameText.text = fi.reporterName.ToString();
        dateText.text = fi.date.ToString();
    }

    public void DeleteReportPressed()
    {
        DismissPopup popup = GV.reportBanUILinks.dismissPopup.GetComponent<DismissPopup>();
        popup.Initialize(flaggedInfo);
        popup.gameObject.SetActive(true);
    }

    public void OpenConvoPressed()
    {
        GV.reportBanUILinks.convoPopup.gameObject.SetActive(true);
    }
}
