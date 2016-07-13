using UnityEngine;
using System.Collections;

public class FlaggedInfo {

    public Date date;
    public int senderId;
    public int destId;
    public string reason;

    public FlaggedInfo(Date _date, int _reporterId, int _flaggedId, string _reason)
    {
        date = _date;
        senderId = _reporterId;
        destId = _flaggedId;
        reason = _reason;
    }

    public FlaggedInfo(FlaggedInfo _toCopy)
    {
        date = _toCopy.date;
        senderId = _toCopy.senderId;
        reason = _toCopy.reason;
        destId = _toCopy.destId;
    }
	
}
