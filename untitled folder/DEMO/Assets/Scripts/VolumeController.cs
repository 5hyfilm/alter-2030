using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class VolumeController : MonoBehaviour
{
	private Slider _slider;
	[SerializeField] private AudioSource _audio;

	private void Start()
	{
		_slider = GetComponent<Slider>();
	}

	void Update ()
	{
		_audio.volume = -80 + (_slider.value * 100);
	}
}
