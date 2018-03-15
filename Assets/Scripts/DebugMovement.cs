using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMovement : MonoBehaviour {

	private int selectedCircleIndex = 0;

	[SerializeField]
	private Circle[] circles = new Circle[3];

	private Circle selectedCircle {
		get {
			return circles[selectedCircleIndex];
		}
	}

	[SerializeField]
	private Color selectedColor, regularColor;

	private void Start() {
		selectedCircle.Color = selectedColor;
	}

	private void FixedUpdate() {
		bool left, right, up, down = false;

		left = Input.GetKey(KeyCode.A);
		right = Input.GetKey(KeyCode.D);
		up = Input.GetKeyDown(KeyCode.W);
		down = Input.GetKeyDown(KeyCode.S);

        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

		if(!selectedCircle.Rotating) {
			if(left && right)
				left = right = false;

			if(up && down)
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
	}

	private void MoveLeft() {
		selectedCircle.MoveLeft();
	}

	private void MoveRight() {
		selectedCircle.MoveRight();
	}

	private void ResetColorFromCircle() {
		selectedCircle.Color = regularColor;
	}

	private void SetColorToCircle() {
		selectedCircle.Color = selectedColor;
	}
}
