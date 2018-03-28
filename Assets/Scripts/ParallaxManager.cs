using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour {

	[SerializeField]
	private float xRot, yRot = 0;

	private static ParallaxManager instance;

	public static float XRot {
		get {
			//if(!instance.enabled)
				return 0;

			return instance.xRot;
		}
	}

	public static float YRot {
		get {
			//if(!instance.enabled)
				return 0;

			return instance.yRot;
		}
	}

	Vector3 offset = Vector3.zero;

	private void Start() {
		instance = this;
		if(!SystemInfo.supportsGyroscope)
			enabled = false;

		Input.gyro.enabled = true;
		offset = Input.gyro.gravity;
	}

	private void FixedUpdate() {
		Vector3 gyroVector = Input.gyro.gravity - offset;
		xRot = gyroVector.y;
		yRot = gyroVector.z;
	}
}
