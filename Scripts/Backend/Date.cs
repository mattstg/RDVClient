using UnityEngine;
using System.Collections;

public struct Date {

    public int day, month, year;

    public Date(int _day, int _month, int _year)
    {
        day = _day;
        month = _month;
        year = _year;
    }

    public override string ToString()
    {
        return (day + "/" + month + "/" + year);
    }
}
