using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour {

	[SerializeField]
	private float xRot, yRot = 0;

	private static ParallaxManager instance;

	public static float XRot {
		get {
			return instance.xRot;
		}
	}

	public static float YRot {
		get {
			return instance.yRot;
		}
	}

	private void Start() {
		instance = this;
		if(!SystemInfo.supportsGyroscope)
			enabled = false;
	}

	private void FixedUpdate() {
		Gyroscope gyro = Input.gyro;

		// Can't leave a bug like that.
		//gyro.gravity
	}
}
