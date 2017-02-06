using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour {

	[SerializeField] float m_SpeedX = 1f;
	[SerializeField] float m_SpeedZ = 1f;
	Vector3 m_Direction;

	// Use this for initialization
	void Start () {
		m_Direction = new Vector3(Random.Range(-1f, 1f) <= 0f ? -1f : 1f, 0f, 1f);	// Set the x value to either -1 or 1
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(m_Direction.x * m_SpeedX * Time.deltaTime, 
							0f,
							m_Direction.z * m_SpeedZ * Time.deltaTime);

		Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
		ChangeDirectionAndClampPosition(viewportPos.x);
		KillOffScreen(viewportPos.y);
	}

	void ChangeDirectionAndClampPosition(float viewportPosX){
		if(viewportPosX < 0f || viewportPosX > 1f){
			m_Direction.x *= -1f;

			Vector3 pos = new Vector3(Mathf.Clamp(viewportPosX, 0f, 1f), 0f, 0f);
			pos = Camera.main.ViewportToWorldPoint(pos);
			transform.position = new Vector3(pos.x, 0f, transform.position.z);
		}
	}

	void KillOffScreen(float viewportPosY){
		if(viewportPosY < 0f || viewportPosY > 1f){
			Destroy(gameObject);
		}
	}
}
