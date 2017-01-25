using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float m_Speed = 0.25f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Moved){
				transform.Translate(touch.deltaPosition.x * m_Speed * Time.deltaTime, 
									0,
									touch.deltaPosition.y * m_Speed * Time.deltaTime);
			}
		}

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		if(horizontal != 0 || vertical != 0){
			transform.Translate(horizontal * m_Speed * 2 * Time.deltaTime, 
								0,
								vertical * m_Speed * 2 * Time.deltaTime);
		}
		ClampPosition();
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
