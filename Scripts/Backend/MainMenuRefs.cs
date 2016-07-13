using UnityEngine;
using System.Collections;

public class MainMenuRefs : MonoBehaviour {

	void Awake () {
        GV.mainMenuRefs = this;
	}
}
