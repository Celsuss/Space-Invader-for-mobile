using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour {

	[SerializeField] float m_SpeedX = 1f;
	[SerializeField] float m_SpeedZ = 1f;
	Vector3 m_Direction;

	// Use this for initialization
	void Start () {
		m_Direction = new Vector3(Random.Range(-1f, 1f) <= 0 ? -1f : 1f, 0, 1f);	// Set the x value to either -1 or 1
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(m_Direction.x * m_SpeedX * Time.deltaTime, 
							0,
							m_Direction.z * m_SpeedZ * Time.deltaTime);

		Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
		ChangeDirection(viewportPos.x);
		KillOffScreen(viewportPos.y);
	}

	void ChangeDirection(float viewportPosX){
		if(viewportPosX <= 0 || viewportPosX >= 1)
			m_Direction.x *= -1;
	}

	void KillOffScreen(float viewportPosY){
		if(viewportPosY < 0 || viewportPosY > 1){
			Destroy(gameObject);
		}
	}
}
