using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMovement : MonoBehaviour {

	private int selectedCircleIndex = 0;

	public static DebugMovement instance;

	[SerializeField]
	private Circle[] circles = new Circle[3];

	[SerializeField]
	private float rotationSpeed = 5;

	public static bool buttonHeld = false;

	private Circle selectedCircle {
		get {
			return circles[selectedCircleIndex];
		}
	}

	public float RotationSpeed {
		get {
			return rotationSpeed;
		}
	}

	[SerializeField]
	private Color selectedColor, regularColor;

	private void Start() {
		instance = this;
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

			bool buttonHeldLastFrame = buttonHeld;

			buttonHeld = up || down || left || right;

			if(!buttonHeld && buttonHeldLastFrame)
				if(ScoreManager.OnBoardChange != null)
					ScoreManager.OnBoardChange();

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
