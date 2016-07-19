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
        GenericPopup gpu = GenericPopup.CreateGenericPopup();
        gpu.SetMainText(varNameText.text + ": " + feild.text);
        gpu.AddButton("Exit");
    }
}
