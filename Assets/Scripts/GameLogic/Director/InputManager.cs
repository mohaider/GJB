using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public enum NumberOfPlayers{
		single, 
		triple
	}
	private static InputManager _instance;
//	public NumberOfPlayers  numOfPlayers;
//	public InputManager Instance{
//		get{
//			if(_instance == null)
//			{
//				GameObject insta = GameObject.FindGameObjectWithTag("InputManager");
//				if(insta !=null)
//				{_instance = insta.GetComponent<InputManager>();
//				if (_instance == null)
//				{
//					_instance = insta.AddComponent<InputManager>();
//				}
//			}
//				else{
//					insta = new GameObject();
//					insta.tag = "InputManager";
//					_instance = insta.AddComponent<InputManager>();
//				}
//			}
//
//		}
//
//
//	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
