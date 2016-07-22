using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MsgBlockUI : MonoBehaviour {

    MsgBlock msgBlock;
    public Text displayText;

    public void Initialize(MsgBlock _msgBlock, bool allignmentLeft)
    {
        msgBlock = _msgBlock;
        displayText.alignment = (allignmentLeft) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;

        if (allignmentLeft)
            displayText.text = "[" + msgBlock.date + "]" + msgBlock.fromWho + ": " + msgBlock.msg;
        else
            displayText.text = msgBlock.msg + " : " + msgBlock.fromWho + "[" + msgBlock.date + "]";

        
    }
}
