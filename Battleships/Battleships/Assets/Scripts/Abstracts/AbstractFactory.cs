﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
	protected GameSettingsModel _gameSettings;

	private void SetGameSettings()
	{
		if (GameController.Instance != null)
		{
			if (GameController.Instance.GameSettings != null)
			{
				_gameSettings = GameController.Instance.GameSettings;
			}
			else
			{
				Debug.LogError("There is not game settings reference set in the GameController!");
			}
		}
		else
		{
			Debug.LogError("There is no GameController instance available!");
		}
	}

	public virtual void Build()
	{
		SetGameSettings();
	}
}
