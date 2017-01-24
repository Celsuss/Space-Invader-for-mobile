using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	[SerializeField] GameObject[] m_Prefabs;
	[SerializeField] float m_SpawnRate = 1;
	float m_NextSpawn;

	// Use this for initialization
	void Start () {
		m_NextSpawn = Time.time + m_SpawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > m_NextSpawn){
			m_NextSpawn = Time.time + m_SpawnRate + Random.Range(0f, 2f);		// Add a random value for more randomness
			m_SpawnRate -= m_SpawnRate / 100;
			Vector3 pos = new Vector3(Random.Range(0f, 1f), 1f, 0);
			pos = Camera.main.ViewportToWorldPoint(pos);
			pos.y = 0;

			int rand = Random.Range(0, m_Prefabs.Length - 1);
			Instantiate(m_Prefabs[rand], pos, m_Prefabs[0].transform.rotation);
		}
	}
}
