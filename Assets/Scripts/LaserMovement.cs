using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {
	[SerializeField] float m_Speed = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
		KillOffScreen();
	}

	void KillOffScreen(){
		float viewportPosY = Camera.main.WorldToViewportPoint(transform.position).y;
		if(viewportPosY < 0 || viewportPosY > 1){
			Destroy(gameObject);
		}
	}
}
