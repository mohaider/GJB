using UnityEngine;
using System.Collections;

public class InGameUI : MonoBehaviour {

	bool inMenu = false;
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("XboxB")) {
			Application.LoadLevel(Application.loadedLevelName);
		}
		if (Input.GetButton("XboxStart")) {
			inMenu = !inMenu;
		}

		if (inMenu) {
			if (Input.GetButton ("Submit")) {
				Application.LoadLevel(0);
			}
		}
	}
}
