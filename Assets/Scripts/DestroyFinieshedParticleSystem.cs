using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinieshedParticleSystem : MonoBehaviour {

	ParticleSystem m_ParticleSystem;

	// Use this for initialization
	void Start () {
		m_ParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!m_ParticleSystem.isPlaying) Destroy(gameObject);
	}
}
