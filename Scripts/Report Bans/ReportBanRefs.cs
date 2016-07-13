using UnityEngine;
using System.Collections;

public class ReportBanRefs : MonoBehaviour {

    public Transform userListGrid;
    public Transform messageGrid;
    public Transform profileGrid;
    public BanReportMS banReportMS;
    public ConvoPopup convoPopup;
    
	void Awake () {
        banReportMS = GetComponent<BanReportMS>();
        GV.reportBanRefs = this;
	}
}
