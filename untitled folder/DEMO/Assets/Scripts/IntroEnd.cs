using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroEnd : MonoBehaviour
{
	[SerializeField]private Canvas _canvas;
	[SerializeField]private VideoPlayer _videoPlayer;
	[SerializeField] private string _nextScene = "GamePlay";
	private bool _skipable;
	void Start () {
		_skipable = false;
		_canvas.gameObject.SetActive(false);
		Invoke("EnableCanvas",5f);
		_videoPlayer.loopPointReached += SkipScene;
	}
	
	void Update () {
		if ((_skipable&&Input.GetButton("Jump")))
		{
			SceneManager.LoadScene(_nextScene);
			Debug.Log("Load");
		}	
	}
	void EnableCanvas()
	{
		_canvas.gameObject.SetActive(true);
		_skipable = true;
	}

	void SkipScene(VideoPlayer vp)
	{
		SceneManager.LoadScene(_nextScene);
		Debug.Log("Load");
	}
	
}
