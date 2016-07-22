using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BanForgivePopup : MonoBehaviour {

    public Text accusedName;
    string accusedId;
   

    public void Initialize(string id)
    {
        accusedName.text = GV.accountRetriever.GetAccountName(id) + " ID(" + id + ")";
        accusedId = id;
    }

    public void BanPressed()
    {
        GenericPopup gpu = GenericPopup.CreateGenericPopup();
        gpu.SetMainText("Are you certain you wish to permanetly ban " + accusedName.text + "?");
        gpu.AddButton("Confirm Ban", BanConfirmed);
        gpu.AddButton("Cancel");
    }

    public void ForgivePressed()
    {
        GenericPopup gpu = GenericPopup.CreateGenericPopup();
        gpu.SetMainText("Are you certain you wish to Forgive " + accusedName.text + "?");
        gpu.AddButton("Confirm Forgiveness", BanConfirmed);
        gpu.AddButton("Cancel");
    }

    public void ClosePressed()
    {
        gameObject.SetActive(false);
    }

    public void BanConfirmed()
    {
        GV.accountRetriever.PermaBanAccount(accusedId);
        GV.reportBanUILinks.banReportMS.UserSelected("");
        ClosePressed();
    }

    public void ForgiveConfirmed()
    {
        GV.accountRetriever.ForgiveAccount(accusedId);
        GV.reportBanUILinks.banReportMS.UserSelected("");
        ClosePressed();
    }
}
