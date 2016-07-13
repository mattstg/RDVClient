using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GenericPopup : MonoBehaviour {

    //upgrade in future so it calls through an internal function, so it can call closed pressed

    public Text text;
    public Transform buttonGrid;
    List<Button> buttons;

    public void SetMainText(string mainText)
    {
        text.text = mainText;
    }

    public void AddButton(string buttonText, System.Action callbackFunc)
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/GenericButton")) as GameObject;
        go.transform.SetParent(buttonGrid);
        UnityEngine.Events.UnityAction castedCallback = new UnityEngine.Events.UnityAction(callbackFunc);
        go.GetComponent<Button>().onClick.AddListener(castedCallback);
        go.GetComponent<Button>().GetComponentInChildren<Text>().text = buttonText;
    }

    public void AddButton(string buttonText)
    {
        GameObject go = Instantiate(Resources.Load("Prefabs/GenericButton")) as GameObject;
        go.transform.SetParent(buttonGrid);
        UnityEngine.Events.UnityAction castedCallback = new UnityEngine.Events.UnityAction(ClosePressed);
        go.GetComponent<Button>().onClick.AddListener(castedCallback);
        go.GetComponent<Button>().GetComponentInChildren<Text>().text = buttonText;
    }

    public void ClosePressed()
    {
        Destroy(this.gameObject);
    }
}
