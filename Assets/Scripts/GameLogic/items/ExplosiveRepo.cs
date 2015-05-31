using UnityEngine;
using System.Collections;
using Assets.Resources.Code.Tools;

public class ExplosiveRepo : MonoBehaviour {

	public enum ExplosionState
	{
		CLASSICEXPLOSION,
		PURPLEEXPLOSIONS

	}

	public  ExplosionState explosiveState;





	private static ExplosiveRepo m_instance;
	


	public static ExplosiveRepo Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = SceneObjectFinder<ExplosiveRepo>.FindGameObjectReturnT("ExpliosionRepo");
				DontDestroyOnLoad(m_instance.gameObject);
			}
			return m_instance;
		}
		set { m_instance = value; }
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject ReturnLargeExplosion()
	{
		return gameObject;
	}

	public GameObject ReturnMediumExplosion()
	{
		return gameObject;


	}

	public GameObject ReturnSmallExplosion()
	{

		return gameObject;

	}
	
}
