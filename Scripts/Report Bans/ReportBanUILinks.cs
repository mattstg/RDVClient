using UnityEngine;
using System.Collections;

public class ReportBanUILinks : MonoBehaviour {

    public Transform userListGrid;
    public Transform messageGrid;
    public Transform profileGrid;
    public BanReportMS banReportMS;
    public ConvoPopup convoPopup;
    public Transform dismissPopup;
    public Transform banForgivePopup;
    public Transform genericPopupParent;
    
	void Awake () {
        banReportMS = GetComponent<BanReportMS>();
        GV.reportBanUILinks = this;
	}
}
