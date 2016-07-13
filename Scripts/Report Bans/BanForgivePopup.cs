using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BanForgivePopup : MonoBehaviour {

    public Text accusedName;
    int accusedId;
   

    public void Initialize(int id)
    {
        accusedName.text = GV.accountRetriever.AccountNameByID(id) + " ID(" + id + ")";
        accusedId = id;
    }

    public void BanPressed()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/GenericPopup")) as GameObject;
        go.transform.SetParent(GV.reportBanUILinks.genericPopupParent,false);
        GenericPopup gpu = go.GetComponent<GenericPopup>();
        gpu.SetMainText("Are you certain you wish to permanetly ban " + accusedName.text + "?");
        gpu.AddButton("Confirm Ban", BanConfirmed);
        gpu.AddButton("Cancel");
    }

    public void ForgivePressed()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/GenericPopup")) as GameObject;
        go.transform.SetParent(GV.reportBanUILinks.genericPopupParent,false);
        GenericPopup gpu = go.GetComponent<GenericPopup>();
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
        Debug.Log("BAN CONFIRMED");
        GV.DeleteChildren(GV.reportBanUILinks.genericPopupParent); //fix internal generic popup so it deletes itself
        GV.reportBanUILinks.banReportMS.UserSelected(-1);
        ClosePressed();
    }

    public void ForgiveConfirmed()
    {
        Debug.Log("FORGIVE CONFIRMED");
        GV.DeleteChildren(GV.reportBanUILinks.genericPopupParent);//fix internal generic popup so it deletes itself
        GV.reportBanUILinks.banReportMS.UserSelected(-1);
        ClosePressed();
    }
}
