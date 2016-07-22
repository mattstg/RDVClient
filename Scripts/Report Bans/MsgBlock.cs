using UnityEngine;
using System.Collections;

public class MsgBlock   {

    public string date, msg, fromWho;

	public MsgBlock(string _date, string _msg, string _fromWho)
    {
        date = _date;
        msg = _msg;
        fromWho = _fromWho;
    }
}
