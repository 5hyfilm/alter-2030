using UnityEngine;

public class WasteCollider : MonoBehaviour
{

	[SerializeField] private GameObject _leaf;
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.CompareTag("Alien"))
		{
			Instantiate(_leaf, gameObject.transform.position, gameObject.transform.rotation);
			Destroy(gameObject);
		}
	}
}
