using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float m_Speed = 0.25f;
	[SerializeField] float m_TiltSpeed = 0;
	[SerializeField] float m_MaxTilt = 75;
	Rigidbody m_Rigidbody;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Moved){
				m_Rigidbody.velocity = new Vector3(touch.deltaPosition.x * m_Speed * 2 * Time.deltaTime,
													0,
													touch.deltaPosition.y * m_Speed * 2 * Time.deltaTime);
			}
		}

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		if(horizontal != 0 || vertical != 0){
			m_Rigidbody.velocity = new Vector3(horizontal * m_Speed * 2 * Time.deltaTime,
												0,
												vertical * m_Speed * 2 * Time.deltaTime);
		}
		RotateShip();
		ClampPosition();
	}

	void RotateShip(){
		Quaternion deltaR = Quaternion.Euler(0, 0, m_Rigidbody.velocity.x * -m_TiltSpeed * Time.deltaTime);
		if(Input.GetAxis("Horizontal") != 0){
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaR);
		}
		else{
			Quaternion targetRot = Quaternion.identity;
			deltaR = Quaternion.RotateTowards(transform.rotation, targetRot, m_TiltSpeed * 5 * Time.deltaTime);
			m_Rigidbody.MoveRotation(deltaR);
		}

		Vector3 euler = m_Rigidbody.rotation.eulerAngles;
		if(euler.z > 180)
			euler.z -= 360;
		transform.rotation = Quaternion.Euler(euler.x, euler.y, Mathf.Clamp (euler.z, -m_MaxTilt, m_MaxTilt));

	}

	// Clamp the position so the object can't move outside the screen.
	void ClampPosition(){
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		Mathf.Clamp(pos.x, 0, 1);
		Mathf.Clamp(pos.y, 0, 1);
		Camera.main.ViewportToWorldPoint(pos);
		transform.position.Set(pos.x, pos.y, pos.z);
	}
}
