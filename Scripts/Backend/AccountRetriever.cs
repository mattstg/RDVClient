using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net;
using System.Text;
using SimpleJSON;
using System.Linq;

//Retrieves info, converts JSON into required type (dictionary mostly)
public class AccountRetriever  {

    string[] serverAddress = new string[] { "http://ord-rdvsupport-test-001.ludia.me:11000/rendezvous-support/" };
    int activeServer = 0;

    public List<string> RetrieveFlaggedAccounts()
    {
        //string jsonString = GetWebRequestJSON("player/block?permanentBanForReview=true");
        //JSONNode json = JSON.Parse(jsonString);
        return GV.fakeServer.GetFlaggedUsers("FlaggedUsers");
    }

    public List<string> RetrieveJailedAccounts()
    {
        List<string> toRet = new List<string>();
        return toRet;
    }

    public Dictionary<string,string> GetAccountInfo(string id)
    {
        Dictionary<string, string> toRet = new Dictionary<string, string>();
        JSONNode json = GetAccountByIdJSON(id);
        
        for(int i = 0; i < json.Count; i++)
            foreach (string s in json[i].Keys)
            {
                if (s == "picture")
                {
                    //do nuttin dont add it
                }
                else if (s == "tags")
                {
                    /*string allTags = "";
                    for (int c = 0; c < json[i]["tags"].Count; c++)
                        allTags += json[i]["tags"][c].Value + ",";
                    toRet.Add("tags", allTags);*/
                    toRet.Add("tags", json[i]["tags"].ToString());
                }
                else
                {
                    KeyValuePair<string, string> kv = new KeyValuePair<string, string>(s, json[i][s].Value);
                    if (!toRet.ContainsKey(kv.Key))
                        toRet.Add(kv.Key, kv.Value);
                }
            }
        return toRet;
    }

    public Stack<MsgBlock> RetrieveConvo(string fromID, string toID, string date)
    {
        string jsonString = GetWebRequestJSON("message?senderId=" + fromID + "&destId=" +toID);
        JSONNode json = JSON.Parse(jsonString);
        Stack<MsgBlock> msgStack = new Stack<MsgBlock>();
        for(int i = 0; i < json["messages"].Count; i++)
        {
            MsgBlock msg = new MsgBlock(json["messages"][i]["createdDatetime"], json["messages"][i]["message"], GV.accountRetriever.GetAccountName(json["messages"][i]["senderId"]));
            msgStack.Push(msg);
        }
        return msgStack;
    }

    public void DeleteBlockFromServer(FlaggedInfo fi)
    {
        Debug.Log("delete from server called");
        DeleteReport(fi.reporterID, fi.reportedID);
    }

    public void TestServerSendWriteRequest()
    {
        // Create a request using a URL that can receive a post. 
        WebRequest request = WebRequest.Create("http://ord-rdvsupport-test-001.ludia.me:11000/rendezvous-support/");
        // Set the Method property of the request to POST.
        request.Method = "POST";
        // Create POST data and convert it to a byte array.
        string postData = "This is a test that posts this string to a Web server.";
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        // Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded";
        // Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length;
        // Get the request stream.
        Stream dataStream = request.GetRequestStream();
        // Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length);
        // Close the Stream object.
        dataStream.Close();
        // Get the response.
        WebResponse response = request.GetResponse();
        // Display the status.
        Console.WriteLine(((HttpWebResponse)response).StatusDescription);
        // Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
        // Display the content.
        Console.WriteLine(responseFromServer);
        // Clean up the streams.
        reader.Close();
        dataStream.Close();
        response.Close();
    }

    public List<FlaggedInfo> GetReportsOnIdJSON(string id)
    {
        List<FlaggedInfo> toRet = new List<FlaggedInfo>();
        string jsonString = GetWebRequestJSON("player/block?accountId=" + id);
        JSONNode json = JSON.Parse(jsonString);
        for(int i = 0; i < json["playerBlocks"].Count; i++)
        {
            string reporter = json["playerBlocks"][i]["senderId"];
            string reason = json["playerBlocks"][i]["reportType"];
            //if (reporter != id && reason != "NONE")
            if (reporter != id)
            {
                FlaggedInfo newFlag = new FlaggedInfo(json["playerBlocks"][i]["lastUpdate"], json["playerBlocks"][i]["senderId"], GetAccountName(json["playerBlocks"][i]["senderId"]), json["playerBlocks"][i]["destId"], json["playerBlocks"][i]["reportType"]);
                toRet.Add(newFlag);
            }
        }
        return toRet;
    }

    private JSONNode GetSpecificBlockReport(string senderId, string destId)
    {
        string jsonString = GetWebRequestJSON("player/block?accountId=" + destId);
        JSONNode json = JSON.Parse(jsonString);
        for (int i = 0; i < json["playerBlocks"].Count; i++)
        {
            JSONNode reportBlock = json["playerBlocks"][i];
            string sender = json["playerBlocks"][i]["senderId"];
            string dest = json["playerBlocks"][i]["destId"];
            if (sender == senderId && destId == dest)
                return reportBlock;
        }
        Debug.LogError("Not found");
        return "";
    }

    public List<string> GetAllPictures(string id)
    {
        List<string> picURLs = new List<string>();
        string jsonString = GetWebRequestJSON("profile/" + id);
        JSONNode json = JSON.Parse(jsonString);
        picURLs.Add(json["accountInfo"]["picture"]["url"]);
        for(int i = 0; i < json["accountInfo"]["secondaryPictures"].Count; i++)
        {
            picURLs.Add(json["accountInfo"]["secondaryPictures"][i]["url"]);
        }
        return picURLs;
    }

    public JSONNode GetAccountByIdJSON(string id)
    {
        string jsonString = GetWebRequestJSON("profile/" + id);
        JSONNode json = JSON.Parse(jsonString);
        return json;
    }

    public string GetAccountName(string id)
    {
        JSONNode json = GetAccountByIdJSON(id);
        return json["accountInfo"]["firstname"] + " " + json["accountInfo"]["lastname"];
    }

    public void DeleteReport(string senderId, string destId)
    {

        JSONNode blockToDelete = GetSpecificBlockReport(senderId, destId); //first extract the report
        
        //then delete report
        string deleteRequest = "player/block?senderId=" + senderId + "&destId=" + destId; 
        SendWebDeleteRequestJSON(deleteRequest);

        //Then re-add the report, but modified
        blockToDelete["reportType"] = "NONE";  //set to a normal block
        PutRequest("player/block", blockToDelete.ToString());
    }

    private void PutRequest(string requestString, string arg)
    {
        var baseAddress = serverAddress[activeServer] + requestString;
        var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
        http.Accept = "application/json";
        http.ContentType = "application/json";
        http.Method = "POST";
        ASCIIEncoding encoding = new ASCIIEncoding();
        Byte[] bytes = encoding.GetBytes(arg);

        Stream newStream = http.GetRequestStream();
        newStream.Write(bytes, 0, bytes.Length);
        newStream.Close();
        var response = http.GetResponse();
    }

    private string GetWebRequestJSON(string requestString)
    {
        string serverurl = serverAddress[activeServer] + requestString;
        WebRequest request = WebRequest.Create(serverurl);
        request.Credentials = CredentialCache.DefaultCredentials;
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        reader.Close();
        response.Close();
        return responseFromServer;
    }

    private bool SendWebDeleteRequestJSON(string requestString)
    {
        try
        {
            string serverurl = serverAddress[activeServer] + requestString;
            WebRequest request = WebRequest.Create(serverurl);
            request.Method = "DELETE";
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void PermaBanAccount(string id)
    {
        string jsonString = GetWebRequestJSON("accountBan/" + id);
        JSONNode accountJson = JSON.Parse(jsonString);
        accountJson["endDate"] = "";
        accountJson["banStatus"] = "APPROVED";

        PutRequest("player/block", accountJson.ToString());
    }

    public void ForgiveAccount(string id)
    {
        string jsonString = GetWebRequestJSON("accountBan/" + id);
        JSONNode accountJson = JSON.Parse(jsonString);

        System.DateTime localDate = System.DateTime.Now;
        string datetimeproper = localDate.Year + "-" + localDate.Month.ToString("00") + "-" + localDate.Day.ToString("00") + "T" + localDate.Hour.ToString("00") + ":" + localDate.Minute.ToString("00") + ":" + localDate.Second.ToString("00");

        accountJson["canceledDate"] = datetimeproper;
        accountJson["banStatus"] = "CANCELED";

        PutRequest("accountBan/", accountJson.ToString());
    }

    
}
