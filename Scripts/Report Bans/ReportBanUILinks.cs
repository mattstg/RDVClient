using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReportBanUILinks : MonoBehaviour {

    public Transform navigationBar;
    public Transform userListGrid;
    public Transform reportGrid;
    public Transform profileGrid;
    public BanReportMS banReportMS;
    public ConvoPopup convoPopup;
    public Transform dismissPopup;
    public Transform banForgivePopup;
    public Transform genericPopupParent;
    public Text headerText;
    public InputField searchBarInput;
    public PictureManager pictureManager;
    public Transform jailImg;
    public Transform banForgiveButton;
    public Transform jailModeButton;
    public Transform reviewModeButton;
    
	void Awake () {
        banReportMS = GetComponent<BanReportMS>();
        GV.reportBanUILinks = this;
	}
}
