using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void LoadSceneByName(string sceneName)
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
