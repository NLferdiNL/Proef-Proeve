using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMovement : MonoBehaviour {

	int selectedCircleIndex = 0;

	[SerializeField]
	Circle[] circles = new Circle[3];

	Circle selectedCircle {
		get {
			return circles[selectedCircleIndex];
		}
	}

	[SerializeField]
	Color selectedColor, regularColor;

	private void Start() {
		selectedCircle.color = selectedColor;
	}

	private void FixedUpdate() {
		bool left, right, up, down = false;

		left = Input.GetKeyDown(KeyCode.A);
		right = Input.GetKeyDown(KeyCode.D);
		up = Input.GetKeyDown(KeyCode.W);
		down = Input.GetKeyDown(KeyCode.S);

		if (left && right)
			left = right = false;

		if (up && down)
			up = down = false;

		if(left)
			MoveRight();

		if(right)
			MoveLeft();

		if(up || down)
			ResetColorFromCircle();

		if(up)
			selectedCircleIndex--;

		if(down)
			selectedCircleIndex++;

		if(selectedCircleIndex <= -1)
			selectedCircleIndex = circles.Length - 1;
		else if(selectedCircleIndex >= circles.Length)
			selectedCircleIndex = 0;

		SetColorToCircle();
	}

	void MoveLeft() {
		selectedCircle.MoveLeft();
	}

	void MoveRight() {
		selectedCircle.MoveRight();
	}

	void ResetColorFromCircle() {
		selectedCircle.color = regularColor;
	}

	void SetColorToCircle() {
		selectedCircle.color = selectedColor;
	}
}
