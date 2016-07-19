using UnityEngine;
using System.Collections;

public class FlaggedInfo {

    public string date;
    public string reporterID;
    public string reportedID;
    public string reason;
    public string reporterName;

    public FlaggedInfo(string _date, string _reporterId, string _reporterName, string _flaggedId, string _reason)
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

    private Date StringToDate(string _date)
    {
        return new Date(0, 0, 0);
    }

    public override string ToString()
    {
        return "date:" + date.ToString() + ", reported id: " + reportedID + ", reporterId: " + reporterID + ", reporterName: " + reporterName + ", reason: " + reason;
    }

}
