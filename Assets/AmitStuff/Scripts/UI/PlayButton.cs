using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour, IClickable {
	UIEventHandler handler;
	// Use this for initialization
	void Start () {
		handler = GameObject.Find ("EventSystem").GetComponent<UIEventHandler> ();
	}
	
	public void OnClick() {
		handler.AddEvent (UIEventHandler.UIEvents.PLAY);
	}
}
