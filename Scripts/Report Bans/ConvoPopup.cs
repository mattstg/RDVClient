using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ConvoPopup : MonoBehaviour {

    public Text userIDText;
    public Text dateText;
    public Transform convoGrid;

    public void Initialize(string fromId, string toId, string date)
    {
        Stack<MsgBlock> msgStack = GV.accountRetriever.RetrieveConvo(fromId, toId, date);
        string fromUserName = GV.accountRetriever.GetAccountName(fromId);
        while(msgStack.Count > 0)
        {
            MsgBlock msgBlock = msgStack.Pop();
            GameObject msgBlockGui = Instantiate(Resources.Load("Prefabs/MsgBlockGUI")) as GameObject;
            msgBlockGui.transform.SetParent(convoGrid);
            bool alignLeft = (fromUserName == msgBlock.fromWho) ? true : false;
            msgBlockGui.GetComponent<MsgBlockUI>().Initialize(msgBlock,alignLeft);

        }
        userIDText.text = GV.accountRetriever.GetAccountName(fromId) + " (" + fromId + ") and " + GV.accountRetriever.GetAccountName(toId) + " (" + toId + ")";
        dateText.text = date.ToString();
    }

    public void ExitButtonPressed()
    {
        GV.DeleteChildren(convoGrid);
        gameObject.SetActive(false);
    }
}
