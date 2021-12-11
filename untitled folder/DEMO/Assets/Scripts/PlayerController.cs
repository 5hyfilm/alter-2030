using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private string _horizontal;
	[SerializeField] private string _vertical;
	private PlayerMotor _playerMotor;
	// Use this for initialization
	void Start ()
	{
		_playerMotor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis(_horizontal);
		float vertical = Input.GetAxis(_vertical);
		_playerMotor.Rotate(horizontal,vertical);
		_playerMotor.Move(horizontal,vertical);
	}
}
