using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserSlot : MonoBehaviour {

    public Text text;
    int userID;

    public void Initialize(int _userID)
    {
        userID = _userID;
        text.text = _userID.ToString();
    }

    public void UserSlotPressed()
    {
        GV.reportBanRefs.banReportMS.UserSelected(userID);
    }

}
