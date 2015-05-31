using UnityEngine;
using System.Collections;
using Assets.Resources.Code.Tools;

public class ExplosiveRepo : MonoBehaviour {

	public enum ExplosionState
	{
		CLASSICEXPLOSION,
		PURPLEEXPLOSIONS

	}

	public  ExplosionState currentexplosiveState;





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

	void Awake()
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject ReturnLargeExplosion()
	{
		if (currentexplosiveState == ExplosionState.CLASSICEXPLOSION) {
			return 	Resources.Load ("Jeff/Explosion_Huge_Classic") as GameObject;
		} else {
			return 	Resources.Load ("Jeff/Explosion_Huge_Purple") as GameObject;
		}

	}

	public GameObject ReturnMediumExplosion()
	{
		if (currentexplosiveState == ExplosionState.CLASSICEXPLOSION) {
			return 	Resources.Load ("Jeff/Explosion_Medium_Classic")as GameObject;
		} else {
			return 	Resources.Load ("Jeff/Explosion_Medium_Purple")as GameObject;
		}


	}
public GameObject ReturnSpecialExplosion()
{

		return 	Resources.Load ("Jeff/Explosion_Huge_Purple_Sim")as GameObject;
	
}

	public GameObject ReturnSmallExplosion()
	{

		if (currentexplosiveState == ExplosionState.CLASSICEXPLOSION) {
			return 	Resources.Load ("Jeff/Explosion_Small_Classic")as GameObject;
		} else {
			return 	Resources.Load ("Jeff/Explosion_Small_Purple")as GameObject;
		}

	}
	
}
