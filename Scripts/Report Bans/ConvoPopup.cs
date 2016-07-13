using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConvoPopup : MonoBehaviour {

    public Text userIDText;
    public Text dateText;
    public Text convoText;

    public void Initialize(int fromId, int toId, Date date)
    {
        convoText.text = GV.accountRetriever.RetrieveConvo(fromId, toId, date);
        userIDText.text = fromId.ToString();
        dateText.text = date.ToString();
    }

    public void ExitButtonPressed()
    {
        convoText.text = "";
        gameObject.SetActive(false);
    }
}
