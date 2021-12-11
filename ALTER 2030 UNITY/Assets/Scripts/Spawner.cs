using UnityEngine;

public class Spawner : MonoBehaviour
{
	private float _x;
	[SerializeField]private float _y = 30f;
	private float _z;
	
	[SerializeField]private Transform _1Pos;
	[SerializeField]private Transform _2Pos;
	
	[SerializeField]private float _delayTime;
	/*[SerializeField]private int _leafQuantity;*/
	[SerializeField]private GameObject[] _waste;

	private void Start()
	{
		InvokeRepeating ("Spawn", _delayTime, _delayTime);
	}

	/*void FixedUpdate ()
	{
		GameObject[] leaf = GameObject.FindGameObjectsWithTag("Waste");
		if (leaf.Length < _leafQuantity)
		{
		}
	}*/

	void Spawn()
	{
		_x = Random.Range(_1Pos.position.x, _2Pos.position.x);
		_z = Random.Range(_1Pos.position.z, _2Pos.position.z);
		Vector3 position = new Vector3(_x,_y,_z);
		int waste = Random.Range(0, _waste.Length-1);
		Instantiate(_waste[waste], position, Quaternion.identity);
	}

}
