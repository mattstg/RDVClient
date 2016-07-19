using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserSlot : MonoBehaviour {

    public Text text;
    string userID;

    public void Initialize(string _userID, string _userName)
    {
        userID = _userID;
        text.text = _userName;
    }

    public void UserSlotPressed()
    {
        GV.reportBanUILinks.banReportMS.UserSelected(userID);
    }

}
