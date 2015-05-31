using UnityEngine;
using System.Collections;

public class LeaderBoardButton : MonoBehaviour, IClickable {
	UIEventHandler handler;
	// Use this for initialization
	void Start () {
		handler = GameObject.Find ("EventSystem").GetComponent<UIEventHandler> ();
	}
	
	public void OnClick() {
		handler.AddEvent (UIEventHandler.UIEvents.LEADERBOARD);
	}
}