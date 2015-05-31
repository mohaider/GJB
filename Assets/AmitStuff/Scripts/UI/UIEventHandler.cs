using UnityEngine;
using System.Collections;

public class UIEventHandler : MonoBehaviour {

	public GameObject mainMenuCanvas, controlsCanvas, creditsCanvas, playCanvas, leaderBoardCanvas;
	public string level1SceneName, level2SceneName, level3SceneName, multiplayerlevelSceneName;

	public enum UIEvents {NOTHING, BACKTOMENU, CONTROLS, CREDITS, PLAY, SINGLE1, SINGLE2, SINGLE3, MULTI1, LEADERBOARD};
	private UIEvents currentEvent;
	// Use this for initialization
	void Start () {
		mainMenuCanvas.SetActive (true);
		controlsCanvas.SetActive (false);
		creditsCanvas.SetActive (false);
		playCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentEvent != UIEvents.NOTHING) {
			switch (currentEvent) {
			case UIEvents.BACKTOMENU:
				mainMenuCanvas.SetActive (true);
				controlsCanvas.SetActive (false);
				creditsCanvas.SetActive (false);
				playCanvas.SetActive (false);
				leaderBoardCanvas.SetActive(false);
				break;
			case UIEvents.CONTROLS:
				controlsCanvas.SetActive (true);
				mainMenuCanvas.SetActive (false);

				break;
			case UIEvents.CREDITS:
				creditsCanvas.SetActive (true);
				mainMenuCanvas.SetActive (false);

				break;
			case UIEvents.PLAY:
				playCanvas.SetActive (true);
				mainMenuCanvas.SetActive (false);

				break;
			case UIEvents.SINGLE1:
				Application.LoadLevel(level1SceneName);
				break;
			case UIEvents.SINGLE2:
				Application.LoadLevel(level2SceneName);
				break;
			case UIEvents.SINGLE3:
				Application.LoadLevel(level3SceneName);
				break;
			case UIEvents.MULTI1:
				Application.LoadLevel(multiplayerlevelSceneName);
				break;
			case UIEvents.LEADERBOARD:
				leaderBoardCanvas.SetActive(true);
				mainMenuCanvas.SetActive (false);

				break;
			}
			currentEvent = UIEvents.NOTHING;
		}
	}

	public void AddEvent(UIEvents e) {
		if (currentEvent == UIEvents.NOTHING) {
			currentEvent = e;
		}
	}
}
