using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour {

	private static int rotationAngle = 45;

	private Image image;

	private RectTransform transform;

	private bool rotating = false;

	[SerializeField]
	private float rotationSpeed = 1;

	public Color Color {
		get {
			if(image == null)
				return Color.white;

			return image.color;
		}

		set {
			if(image == null)
				return;

			image.color = value;
		}
	}

	public bool Rotating {
		get {
			return rotating;
		}

		set {
			rotating = value;
		}
	}

	private void Start() {
		image = GetComponent<Image>();
		transform = GetComponent<RectTransform>();
	}

	public void GenerateIcons() {

	}

	public void Generate() {
		// Place icons
	}

	public void MoveLeft() {
		StartCoroutine(Move(-rotationAngle));
	}

	public void MoveRight() {
		StartCoroutine(Move(rotationAngle));
	}

	IEnumerator Move(float addedAngle) {
		if(!rotating) {
			rotating = true;

			Quaternion goalAngle = transform.rotation * Quaternion.Euler(0, 0, addedAngle);
			Quaternion startAngle = transform.rotation;

			float position = 0;

			while(position < 1) {
				position += Time.deltaTime * rotationSpeed;
				transform.rotation = Quaternion.Lerp(startAngle, goalAngle, position);
				yield return new WaitForEndOfFrame();
			}

			transform.rotation = goalAngle;
			rotating = false;
		}
	}
}
