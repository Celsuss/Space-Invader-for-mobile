using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	[SerializeField] GameObject m_LaserPrefab;
	[SerializeField] float m_FireRate = 1;
	float m_NextFire;

	// Use this for initialization
	void Start () {
		m_NextFire = Time.time + m_FireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > m_NextFire){
			m_NextFire = Time.time + m_FireRate;
			Quaternion rot = Quaternion.Euler(m_LaserPrefab.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, m_LaserPrefab.transform.rotation.eulerAngles.z);
			GameObject obj = Instantiate(m_LaserPrefab, transform.position, rot);
			obj.layer = gameObject.layer;
		}
	}
}