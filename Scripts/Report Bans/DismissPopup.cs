using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DismissPopup : MonoBehaviour {

    FlaggedInfo flaggedInfoToRemove;
    public Text dynamicText;

	public void Initialize(FlaggedInfo fi)
    {
        flaggedInfoToRemove = fi;
        SetText();
    }


    public void DeleteReport()
    {
        GV.accountRetriever.DeleteBlockFromServer(flaggedInfoToRemove);
        ClosePopup();
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
        flaggedInfoToRemove = null;
    }

    private void SetText()
    {
        dynamicText.text = "Reported by: " + flaggedInfoToRemove.reporterName + ", ID: " + flaggedInfoToRemove.reporterID + " for reason of: " + flaggedInfoToRemove.reason;
    }
}

