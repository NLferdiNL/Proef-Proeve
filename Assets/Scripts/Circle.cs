using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour {

	[SerializeField]
	private IconClass[] icons;

	private int rotationAngle = 45;

	[SerializeField]
	private int iconsInCircle = 8;

	private float currentAngle = 0;

	private Image image;

	private int currentOffset = 0;

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
	private RectTransform transform;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

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
		rotationAngle = 360 / iconsInCircle;
		GenerateIcons();
	}

	public IconClass GetIcon(int index) {
		index += currentOffset;

		if(index < 0)
			index = icons.Length;
		else if(index >= icons.Length)
			index = 0;

		return icons[index];
	}

	public void GenerateIcons() {
		icons = new IconClass[iconsInCircle];
		
		for(int i = 0; i < iconsInCircle; i++) {
			GameObject iconContainer = Instantiate(IconAssetData.Instance.IconPrefab, Vector3.zero, Quaternion.identity, transform);
			iconContainer.name = "Icon " + i;
			IconClass iconClass = iconContainer.GetComponent<IconClass>();
			iconClass.Icon = IconAssetData.Instance.GetRandomIcon();

			icons[i] = iconClass;
			
		}
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

			if(addedAngle < 0)
				currentOffset--;
			else
				currentOffset++;

			if(currentOffset < 0)
				currentOffset = icons.Length;
			else if(currentOffset >= icons.Length)
				currentOffset = 0;

			while(position < 1) {
				position += Time.deltaTime * rotationSpeed;
				transform.rotation = Quaternion.Lerp(startAngle, goalAngle, position);
				yield return new WaitForEndOfFrame();
			}

			transform.rotation = goalAngle;
			currentAngle = goalAngle.z;
			rotating = false;
		}
	}
}
