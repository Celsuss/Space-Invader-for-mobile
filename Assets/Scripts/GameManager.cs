using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	static GameManager _instance;
	[SerializeField] GameObject[] m_EnemyPrefabs;
	[SerializeField] float m_WaveWaitTime;
	[SerializeField] float m_SpawnWaitTime;
	[SerializeField] float m_WaveCount;
	//[SerializeField] GameObject
	[SerializeField] Text m_ScoreText;
	[SerializeField] Text m_RestartText;
	[SerializeField] Text m_GameOverText;
	int m_Score;
	bool m_Restart;
	bool m_GameOver;

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
        //DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
		m_Score = 0;
		m_GameOver = false;
		m_GameOverText.text = "";
		m_RestartText.text = "";
		StartCoroutine(SpawnEnemy());
		UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
		Restart();
	}

	void UpdateScore() {
		m_ScoreText.text = "Score: " + m_Score;
	}

	void Restart(){
		if(m_Restart){
			if(Input.touchCount > 0 || Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	public void AddScore( int scoreValue ){
		m_Score += scoreValue;
		UpdateScore();
	}

	public void GameOver(){
		m_GameOverText.text = "Game Over";
		m_GameOver = true;
	}


	IEnumerator SpawnEnemy () {
		Random.InitState(50);
		while(!m_GameOver){
			for(int i = 0; i < m_WaveCount; i++){
				Vector3 pos = new Vector3(Random.Range(0f, 1f), 1f, 0);
				pos = Camera.main.ViewportToWorldPoint(pos);
				pos.y = 0;

				int rand = Random.Range(0, m_EnemyPrefabs.Length);
				Instantiate(m_EnemyPrefabs[rand], pos, m_EnemyPrefabs[rand].transform.rotation);

				if(IsGameOver()) break;
				yield return new WaitForSecondsRealtime (m_SpawnWaitTime);
			}

			m_WaveCount++;
			if(IsGameOver()) break;
			yield return new WaitForSecondsRealtime (m_WaveWaitTime);
		}
	}

	bool IsGameOver(){
		if(m_GameOver){
			m_RestartText.text = "Touch the screen to restart game\n or press 'R'";
			m_Restart = true;
			return true;
		}
		return false;
	}
}
