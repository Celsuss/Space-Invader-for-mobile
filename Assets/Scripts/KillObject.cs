using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObject : MonoBehaviour {

	[SerializeField] GameObject m_ExplosionPrefab;
	[SerializeField] int m_ScoreValue = 0;

	void OnCollisionEnter(Collision collision) {
		DestroyObject();
	}

	void OnTriggerEnter(Collider collider){
		DestroyObject();
	}

	void DestroyObject(){
		if(m_ExplosionPrefab)
			Instantiate(m_ExplosionPrefab, transform.position, transform.rotation);
		if(m_ScoreValue != 0)
			GameManager.Instance.AddScore(m_ScoreValue);
		if(gameObject.tag == "Player")
			GameManager.Instance.GameOver();
		Destroy(gameObject);
	}
}
