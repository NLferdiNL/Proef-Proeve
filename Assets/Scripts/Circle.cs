﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour {

	[SerializeField]
	private IconClass[] icons;
	// The icons this circle holds.

	private int rotationAngle = 45;
	// The angle the icons need to rotate.
	// 360 / iconsInCircle = rotationAngle
	
	private int iconsInCircle {
		get {
			return IconAssetData.Instance.IconsInCircle;
		}
	}
	//Shortcut to the integer.

	private float currentAngle = 0;
	// Current Z rotation

	private Image image;
	// To change color.

	[SerializeField]
	private int currentOffset = 0;
	// Icon array offset caused by rotation.

	[SerializeField]
	RectTransform itemPivot;
	// The starting points for generating icons.

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
	private RectTransform transform;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

	private bool rotating = false;
	// Is this circle rotating.

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

	// Returns Icon keeping offset in mind.
	public IconClass GetIcon(int index) {
		index += currentOffset;

		if(index < 0)
			index = icons.Length;
		else if(index >= icons.Length)
			index = 0;

		return icons[index];
	}

	// Setup icons on this circle
	public void GenerateIcons() {
		icons = new IconClass[iconsInCircle];
		
		for(int i = 0; i < iconsInCircle; i++) {
			GameObject iconContainer = Instantiate(IconAssetData.Instance.IconPrefab, Vector3.zero, Quaternion.identity, transform);
			iconContainer.name = "Icon " + i;

			IconClass iconClass = iconContainer.GetComponent<IconClass>();
			iconClass.Icon = IconAssetData.Instance.GetRandomIcon();

			RectTransform iconRect = iconContainer.GetComponent<RectTransform>();
			iconRect.position = itemPivot.position;
			iconRect.sizeDelta = itemPivot.sizeDelta;// + new Vector2(itemPivot.sizeDelta.x, 0);
			iconRect.RotateAround(transform.position, Vector3.forward, rotationAngle*i);

			icons[i] = iconClass;
			
		}
	}

	public void MoveLeft() {
		StartCoroutine(Move(-rotationAngle));
	}

	public void MoveRight() {
		StartCoroutine(Move(rotationAngle));
	}

	// Makes the animation happen.
	IEnumerator Move(float addedAngle) {
		if(!rotating) {
			rotating = true;

			Quaternion goalAngle = transform.rotation * Quaternion.Euler(0, 0, addedAngle);
			Quaternion startAngle = transform.rotation;

			float position = 0;

			if(addedAngle < 0)
				currentOffset++;
			else
				currentOffset--;

			if(currentOffset < 0)
				currentOffset = icons.Length - 1;
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

			if(ScoreCheck.OnBoardChange != null)
				ScoreCheck.OnBoardChange();
		}
	}
}
