using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	private Image image;
	[SerializeField] private LevelState levelState;
	[SerializeField] private bool isHeaven = true;
	private Coroutine ticker;
	[SerializeField] float refreshRateSeconds;
	[SerializeField] private float incrementPerSecond;
	[SerializeField] private FlipScript flipScript;
	private void Awake() => image = GetComponent<Image>();
    [SerializeField] private ScoreDataSO scoreDataSo;


	private void OnEnable()
	{
        if (flipScript == null) Debug.LogWarning("No flip script on progress bar");
        else flipScript.OnPhaseChange += UpdateDirection;
		levelState.OnLevelStart += StartLevel;
		levelState.OnLevelEnd += StopLevel;
	}

	private void OnDisable()
	{
		//flipScript.OnPhaseChange-= UpdateDirection;
		levelState.OnLevelStart -= StartLevel;
		levelState.OnLevelEnd -= StopLevel;
	}


	private void UpdateDirection(bool _isHeaven) => isHeaven = _isHeaven;
	

	private void UpdateSlider(float amount)
	{
		if (isHeaven) image.fillAmount += amount;
		else image.fillAmount -= amount;
        scoreDataSo.progressBar = image.fillAmount;

    }

	private void StartLevel()
	{
		StopLevel();
		ticker = StartCoroutine(Tick());
	}

	private void StopLevel()
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

	private float ConvertToSlideVal(float _incrementPerSecond)
	{
		return (refreshRateSeconds * _incrementPerSecond) / 25;
	}
}