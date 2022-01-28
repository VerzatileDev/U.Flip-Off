using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] private LevelState levelState;
	

	private void Start()
	{
		LevelStart();
	}

	private void LevelStart()
	{
		levelState.SetIsGameStarted(true);
	}

	public void LevelEnd()
	{
		levelState.SetIsGameStarted(false);

	}
}
