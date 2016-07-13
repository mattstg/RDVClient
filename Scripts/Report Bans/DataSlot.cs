using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataSlot : MonoBehaviour {

    public InputField feild;
    public Text varNameText;

    public void Initialize(string _varName, string value)
    {
        varNameText.text = _varName;
        feild.text = value;
    }

    public void ClickedOn()
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/GenericPopup")) as GameObject;
        go.transform.SetParent(GV.reportBanUILinks.genericPopupParent, false);
        GenericPopup gpu = go.GetComponent<GenericPopup>();
        gpu.SetMainText(varNameText.text + ": " + feild.text);
        gpu.AddButton("Exit");
    }
}
