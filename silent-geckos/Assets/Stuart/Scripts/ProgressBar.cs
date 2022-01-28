using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	private Image image;
	[SerializeField]private bool isHeaven = true;
	private Coroutine ticker;
	[SerializeField] float refreshRateSeconds;
	[SerializeField] private float incrementPerSecond;
	private void Awake() => image = GetComponent<Image>();
	
	
	//private void OnEnable() PetesScript.OnPhaseChange += UpdateDirection
	
	//private void OnDisable() =>PetesScript.Default.LeftClick.started += UpdateDirection;

	private void Start()
	{
		StartLevel();
	}

	private void UpdateDirection(bool _isHeaven)
	{
		isHeaven = _isHeaven;
	}

	private void UpdateSlider(float amount)
	{
		if (isHeaven) image.fillAmount += amount;
		else image.fillAmount -= amount;
	}
	public void StartLevel()
	{
		StopLevel();
		ticker = StartCoroutine(Tick());
	}

	public void StopLevel()
	{
		StopCoroutine(Tick());
		ticker = null;
	}

	private IEnumerator Tick()
	{
		while (true)
		{
			yield return new WaitForSeconds(refreshRateSeconds);
			UpdateSlider(ConvertToSlideVal(incrementPerSecond));
		}
	}

	private float  ConvertToSlideVal(float _incrementPerSecond)
	{
		return (refreshRateSeconds*_incrementPerSecond)/25;
	}
}
