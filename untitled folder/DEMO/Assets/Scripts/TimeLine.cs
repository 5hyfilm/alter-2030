using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimeLine : MonoBehaviour
{

	private PlayableDirector di;

	void Start ()
	{
		di = GetComponent<PlayableDirector>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (di.state != PlayState.Playing)
		{
			SceneManager.LoadScene("Menu");
		}
	}
}
