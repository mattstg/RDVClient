using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountInfo : MonoBehaviour {

    //I think it's just a dictionary
    Dictionary<string, string> accountDict = new Dictionary<string, string>();


    public T GetData<T>(string key)
    {
        if (accountDict.ContainsKey(key))
            return (T)System.Convert.ChangeType(accountDict[key], typeof(T));
        else
            Debug.LogError("key: " + key + " was not found");
        return (T)System.Convert.ChangeType(0, typeof(T));
    }

    public void SetValue(string key, string value)
    {
        if (accountDict.ContainsKey(key))
            accountDict[key] = value;
        else
            accountDict.Add(key, value);
    }

}
