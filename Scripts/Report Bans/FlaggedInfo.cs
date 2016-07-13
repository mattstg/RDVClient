using UnityEngine;
using System.Collections;

public class FlaggedInfo {

    public Date date;
    public int reporterID;
    public int reportedID;
    public string reason;
    public string reporterName;

    public FlaggedInfo(Date _date, int _reporterId, string _reporterName, int _flaggedId, string _reason)
    {
        date = _date;
        reporterID = _reporterId;
        reporterName = _reporterName;
        reportedID = _flaggedId;
        reason = _reason;
    }

    public FlaggedInfo(FlaggedInfo _toCopy)
    {
        date = _toCopy.date;
        reporterID = _toCopy.reporterID;
        reason = _toCopy.reason;
        reportedID = _toCopy.reportedID;
        reporterName = _toCopy.reporterName;
    }
	
}
