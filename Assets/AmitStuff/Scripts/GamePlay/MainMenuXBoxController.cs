using UnityEngine;
using System.Collections;

public class MainMenuXBoxController : MonoBehaviour {
	public UnityEngine.UI.Button[] buttonsTopDown;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B)) {
			buttonsTopDown [0].SendMessage ("OnClick");
		}
	
	}
}
