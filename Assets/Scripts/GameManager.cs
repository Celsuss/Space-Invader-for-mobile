using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	static GameManager _instance;
	[SerializeField] GameObject[] m_EnemyPrefabs;
	[SerializeField] float m_WaveWaitTime;
	[SerializeField] float m_SpawnWaitTime;
	[SerializeField] float m_WaveCount;
	//[SerializeField] GameObject
	[SerializeField] Text m_ScoreText;
	int m_Score;

	// Use this for initialization
	private GameManager(){}

	public static GameManager Instance
    {
        get
        {
            if(_instance == null)
				_instance = new GameManager();
            return _instance;
        }
    }

	void Awake()
    {
		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
		m_Score = 0;
		StartCoroutine(SpawnEnemy());
		UpdateScore();
		Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateScore() {
		m_ScoreText.text = "Score: " + m_Score;
	}

	public void AddScore( int scoreValue ){
		Debug.Log("Added Score");
		m_Score += scoreValue;
		UpdateScore();
	}

	IEnumerator SpawnEnemy () {
		while(true){
			for(int i = 0; i < m_WaveCount; i++){
				Vector3 pos = new Vector3(Random.Range(0f, 1f), 1f, 0);
				pos = Camera.main.ViewportToWorldPoint(pos);
				pos.y = 0;

				int rand = Random.Range(0, m_EnemyPrefabs.Length - 1);
				Instantiate(m_EnemyPrefabs[rand], pos, m_EnemyPrefabs[rand].transform.rotation);
				yield return new WaitForSecondsRealtime (m_SpawnWaitTime);
			}
			m_WaveCount++;
			yield return new WaitForSecondsRealtime (m_WaveWaitTime);
		}
	}
}
