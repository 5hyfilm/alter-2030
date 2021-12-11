using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
	[SerializeField]private ParticleSystem _part;
	private GameManager _gameMan;
	void Start ()
	{
		_gameMan = FindObjectOfType<GameManager>();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Human")&&_gameMan.Leaves != 0)
		{
			_gameMan.GetScore(_gameMan.ScorePerPieces * _gameMan.Leaves);
			_gameMan.Leaves = 0;
			var col = _part.colorOverLifetime;
			col.color = Color.green;
		}
	}

	void OnTriggerExit(Collider other)
	{
		var col = _part.colorOverLifetime;
		col.color = Color.red;
	}
}
