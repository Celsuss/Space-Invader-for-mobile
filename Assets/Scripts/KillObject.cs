using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour {

	[SerializeField] GameObject m_ExplosionPrefab;

	void OnCollisionEnter(Collision collision) {
		if(m_ExplosionPrefab)
			Instantiate(m_ExplosionPrefab, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider collider){
		if(m_ExplosionPrefab){
			Instantiate(m_ExplosionPrefab, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}
