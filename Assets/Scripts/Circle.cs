using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour {

	static int _rotationAngle = 45;

	Image _image;

	RectTransform _transform;

	bool _rotating = false;

	[SerializeField]
	float _rotationSpeed = 1;

	public Color color {
		get {
			if(_image == null)
				return Color.white;

			return _image.color;
		}

		set {
			if(_image == null)
				return;

			_image.color = value;
		}
	}

	private void Start() {
		_image = GetComponent<Image>();
		_transform = GetComponent<RectTransform>();
	}

	public void Generate() {
		// Place images
	}

	public void MoveLeft() {
		StartCoroutine(Move(-_rotationAngle));
	}

	public void MoveRight() {
		StartCoroutine(Move(_rotationAngle));
	}

	IEnumerator Move(float addedAngle) {
		if(!_rotating) {
			_rotating = true;

			Quaternion goalAngle = _transform.rotation * Quaternion.Euler(0, 0, addedAngle);
			Quaternion startAngle = _transform.rotation;

			float position = 0;

			while(position < 1) {
				position += Time.deltaTime * _rotationSpeed;
				_transform.rotation = Quaternion.Lerp(startAngle, goalAngle, position);
				yield return new WaitForEndOfFrame();
			}

			_transform.rotation = goalAngle;
			_rotating = false;
		}
	}
}
