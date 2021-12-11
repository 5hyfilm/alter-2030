using System;
using System.Collections;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
	[SerializeField] private float _speed;
	private Animator _animator;
	private float _playerSpeed;
	private Rigidbody _playerRigidbody;
	private Quaternion _playerRotation = new Quaternion(0,0,0,1);
	private AudioSource _audio;

	void Start ()
	{
		_audio = GetComponent<AudioSource>();
		_animator = GetComponent<Animator>();
		_playerRigidbody = GetComponent<Rigidbody>();
		InvokeRepeating ("PlaySound", 0.0f, 0.5f); 
     	}
	void Update ()
	{
		if (!IsGrounded())
		{
			_playerRigidbody.AddForce(0,-500f,0);
			_audio.Stop();
		}
		_playerRigidbody.rotation = _playerRotation;
		_animator.SetFloat("Speed",_playerSpeed);
	}

	bool IsGrounded()
	{
		return Physics.Raycast(_playerRigidbody.position+new Vector3(0,0.1f,0), Vector3.down, 0.2f);
	}

	public void Rotate(float h, float v)
	{
		if (Math.Abs(v+h) > 0)
		{
			_playerRotation = Quaternion.Euler(new Vector4(0,Mathf.Atan2(h, v)* Mathf.Rad2Deg,0,877f));
		}
	}

	public void Move(float h, float v)
	{
		_playerRigidbody.velocity = new Vector3(h,0,v)*_speed;
		_playerSpeed = Mathf.Abs(h)+Mathf.Abs(v);
	}

	void PlaySound()
	{
		if (IsGrounded() && Math.Abs(_playerRigidbody.velocity.x + _playerRigidbody.velocity.y) > 0)
		{
			_audio.Play();
		}
	}
}
