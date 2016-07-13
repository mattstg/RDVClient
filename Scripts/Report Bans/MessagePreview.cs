using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagePreview : MonoBehaviour {

    public Date dateConvoOccured;
    public Text toText;   //text for who the message was sent to
    public Text dateText; //the date the convo took  place
    public Text previewText; //text showing preview of convo right before report
	
    public void Initialize(FlaggedInfo fi)
    {
        toText.text = fi.destId.ToString();
        dateText.text = fi.date.ToString();
        GV.accountRetriever.RetrieveConvo(fi.senderId, fi.destId, fi.date);
    }

    public void DeleteReportPressed()
    {

    }

    public void OpenConvoPressed()
    {
        GV.reportBanRefs.convoPopup.gameObject.SetActive(true);


    }
}
