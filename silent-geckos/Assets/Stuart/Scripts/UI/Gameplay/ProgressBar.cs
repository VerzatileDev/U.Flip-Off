using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class ProgressBar : MonoBehaviour
{
	private Image image;
	[SerializeField] private LevelState levelState;
	[SerializeField] private bool isHeaven = true;
	private Coroutine ticker;
	[SerializeField] float refreshRateSeconds;
	[SerializeField] private float incrementPerSecond;
	[SerializeField] private FlipScript flipScript;
	const int range=300;

	private void Awake()
	{
		image = GetComponent<Image>();
		respawn = FindObjectOfType<Respawn>();
		if(respawn==null) Debug.LogWarning("respawn not found");

	} 
    [SerializeField] private ScoreDataSO scoreDataSo;
    [SerializeField] private Image sliderImage;
    private Respawn respawn;
    
	private void OnEnable()
	{
        if (flipScript == null) Debug.LogWarning("No flip script on progress bar");
        else flipScript.OnPhaseChange += UpdateDirection;
		levelState.OnLevelStart += StartLevel;
		levelState.OnLevelEnd += StopLevel;
		if (respawn != null) respawn.OnRespawn += Respawn;
	}

	private void Respawn()
	{
		SetSliderPosition();
	}

	private void SetSliderPosition()
	{
		RectTransform rectTransform = sliderImage.GetComponent<RectTransform>();
		rectTransform.localPosition = new Vector3(Map(scoreDataSo.progressBar, 0,1,range*-1, range),
			rectTransform.localPosition.y, rectTransform.localPosition.z);
	}


	private void OnDisable()
	{
		//flipScript.OnPhaseChange-= UpdateDirection;
		levelState.OnLevelStart -= StartLevel;
		levelState.OnLevelEnd -= StopLevel;
		if (respawn != null) respawn.OnRespawn -= Respawn;

	}


	private void UpdateDirection(bool _isHeaven) => isHeaven = _isHeaven;
	
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


	
	private void UpdateSlider(float amount)
	{
		RectTransform rectTransform = sliderImage.GetComponent<RectTransform>();
		Vector3 currentPos = rectTransform.localPosition;
		if (isHeaven)
		{
			if (currentPos.x +amount< range) rectTransform.localPosition = new Vector3(currentPos.x+=amount,currentPos.y,currentPos.z);
		}
		else
		{
			if (currentPos.x -amount> range*-1) rectTransform.localPosition = new Vector3(currentPos.x-=amount,currentPos.y,currentPos.z);
		}
		scoreDataSo.progressBar = Map((int)rectTransform.localPosition.x,range*-1, range, 0,1);
		            var emitter = FindObjectOfType<StudioEventEmitter>();
          // 	emitter.SetParameter("Slider", scoreDataSo.progressBar);
		  emitter.SetParameter("Slider", 1f);

	}
	private float ConvertToSlideVal(float _incrementPerSecond)
	{
		return (refreshRateSeconds * _incrementPerSecond) / 25;
	}

	private static float Map(float value, int startLow, int startHigh, int toLow, int toHigh) 
	{
		float val =(value - startLow) * (toHigh - toLow) / (startHigh - startLow) + toLow;
		return val;
	}
}