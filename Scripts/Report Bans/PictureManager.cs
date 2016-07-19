using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PictureManager : MonoBehaviour {

    //no need to get GV.UI. parent since this is attached to the grid

	public void Initialize(string id)
    {
        ClearPanel();
        List<string> picURLs = GV.accountRetriever.GetAllPictures(id);
        foreach(string picURL in picURLs)
        {
            StartCoroutine(LoadPicture(picURL));
        }
        //
        //Go.setParent(transform,false)
    }

    IEnumerator LoadPicture(string url)
    {
        WWW www = new WWW(url);

        // Wait for download to complete
        yield return www;
        
        // assign texture
        GameObject go = Instantiate(Resources.Load("Prefabs/UserPicture")) as GameObject;
        go.transform.SetParent(GV.reportBanUILinks.pictureManager.transform, false);
        RawImage rawImg = go.GetComponent<RawImage>();
        Texture2D t2d = www.texture;
        rawImg.texture = t2d;
    }

    void ClearPanel()
    {
        GV.DeleteChildren(GV.reportBanUILinks.pictureManager.transform);
    }
}
