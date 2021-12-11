using UnityEngine;

public class LeafCollider : MonoBehaviour {

	private GameManager _gameMan;
	void Start ()
	{
		_gameMan = FindObjectOfType<GameManager>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.CompareTag("Human")&&_gameMan.Leaves < _gameMan.MaxCarryLeaves)
		{
			_gameMan.Leaves += 1;
			Destroy(gameObject);
		}else if (other.transform.CompareTag("Ground"))
		{
			Destroy(gameObject);
		}
	}
}
