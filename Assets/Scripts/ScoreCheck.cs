using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour {

	public delegate void BoardChanged();

	public static event BoardChanged EventHandler;

	private void Start() {
		EventHandler += ScoreCheck_EventHandler;
	}

	private void ScoreCheck_EventHandler() {

	}
}
