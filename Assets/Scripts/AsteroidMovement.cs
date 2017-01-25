using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

	[SerializeField] float m_SpeedZ = 1f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * -m_SpeedZ;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
		KillOffScreen(viewportPos.y);
	}

	void KillOffScreen(float viewportPosY){
		if(viewportPosY < 0 || viewportPosY > 1){
			Destroy(gameObject);
		}
	}
}
