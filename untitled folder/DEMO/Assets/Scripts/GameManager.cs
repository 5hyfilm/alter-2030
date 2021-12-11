using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	[SerializeField] private Text _leavesText;
    [SerializeField]private Slider _scoreFill;
	[SerializeField] private int _wave;
	[SerializeField] private Canvas _waveMenu;
	[SerializeField] private Text _winText;
	[SerializeField] private Text _timer;
	private float _time;
	public float Score;
    private float _maxScore;
	public int Leaves;
	public int MaxCarryLeaves;
	public int ScorePerPieces;

	void Start()
	{
		Debug.Log(PlayerPrefs.GetInt("CurrentWave"));
		_time = 70 - (PlayerPrefs.GetInt("CurrentWave")*6);
		_maxScore = 15 + (PlayerPrefs.GetInt("CurrentWave") * 4);
	}

	void Update ()
	{
		var t = TimeSpan.FromSeconds(_time);
		_timer.text = "Time : " + string.Format("{0}:{1}:{2}", t.Minutes, t.Seconds,t.Milliseconds);
		_time -= Time.deltaTime;
		_scoreFill.value = Score / _maxScore;
		_leavesText.text = "Leaves : " + Leaves;
		if (_time <= 0)
		{
			StartCoroutine(LoseMenu());
		}
		if (Score >= _maxScore)
		{
			StartCoroutine(WinMenu());
		}
	}

	public void GetScore(int score)
	{
		if (Score < _maxScore)
		{
			Score += score;
		}
		else
		{
			Score = _maxScore;
		}
	}

	IEnumerator WinMenu()
	{
		_waveMenu.gameObject.SetActive(true);
		_winText.text = "Wave " + (PlayerPrefs.GetInt("CurrentWave")+1) + " Win.";
		yield return new WaitForSeconds(2);
		if (PlayerPrefs.GetInt("CurrentWave") < _wave)
		{
			int cur = PlayerPrefs.GetInt("CurrentWave") + 1;
			PlayerPrefs.SetInt("CurrentWave", cur);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
		{
			SceneManager.LoadScene("Good_End");
		}
	}
	IEnumerator LoseMenu()
	{
		_waveMenu.gameObject.SetActive(true);
		_winText.text = "GameOver";
		yield return new WaitForSeconds(2);
		PlayerPrefs.SetInt("CurrentWave",0);
		SceneManager.LoadScene("BAD_end");
	}
}
