using UnityEngine;
using System.Collections;

public class LaserPointer : MonoBehaviour {
	public Light m_PointerLight;
	private Ray ray;
	private RaycastHit m_hit;
	private LineRenderer m_lineRenderer;
	private Color m_Color;
	public float MaxDistance;
	public float maxWidth;
	public Rigidbody parentRigid;
	public GameObject lift;
	public LayerMask m_LayerMask;
	
	public Material mat;
	// Use this for initialization
	void Start () {
		m_lineRenderer=gameObject.AddComponent<LineRenderer>();
		m_lineRenderer.SetPosition (0, transform.position);
		m_lineRenderer.SetPosition (1, transform.forward);
		m_lineRenderer.SetColors (m_PointerLight.color, m_PointerLight.color);
		m_lineRenderer.SetWidth (maxWidth,maxWidth);
		m_lineRenderer.material = mat;
		lift = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forwardVector = lift.transform.forward;
		//forwardVector.y = 0;
		Vector3 tPosition = transform.position;
		m_lineRenderer.SetPosition (0, transform.position);
		
		
		if (Physics.SphereCast (tPosition, 0.5f,forwardVector, out m_hit, MaxDistance,m_LayerMask)) {
			print ("colliding!~");
			Vector3 hitpoint =transform.position+ forwardVector * m_hit.distance;
			m_PointerLight.transform.position = hitpoint;
			m_lineRenderer.SetPosition (1, hitpoint);
			
		} else {
			m_PointerLight.transform.position = transform.position;
			m_lineRenderer.SetPosition (1, transform.position);
		}
		
	}
}
