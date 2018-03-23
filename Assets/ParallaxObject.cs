using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxObject : MonoBehaviour {

	[SerializeField]
	float depth = -1;

	[SerializeField]
	bool useZ = true;

	Vector3 startPosition;

	private void Start() {
		if(useZ)
			depth = transform.position.z;

		startPosition = transform.position;
	}

	private void FixedUpdate() {
		transform.position = startPosition + transform.right * ParallaxManager.XRot * depth + transform.up * ParallaxManager.YRot * depth;
	}
}
