using UnityEngine;

[ExecuteInEditMode]
public class IconContainer : MonoBehaviour {

	static IconContainer instance;

	public static IconContainer Instance {
		get {
			if(instance == null)
				instance = FindObjectOfType<IconContainer>();

			return instance;
		}
	}

	public IconObject[] icons;

	[SerializeField]
	private Sprite squiggleEdgeSprite;

	[SerializeField]
	private Sprite ovalEdgeSprite;

	[SerializeField]
	private Sprite diamondEdgeSprite;

	[SerializeField]
	private Sprite openShadingSprite;

	[SerializeField]
	private Sprite stripedShadingSprite;

	[SerializeField]
	private Sprite solidShadingSprite;

	[SerializeField]
	private Color redColor = Color.red;

	[SerializeField]
	private Color greenColor = Color.green;

	[SerializeField]
	private Color purpleColor = Color.magenta;

	public Sprite SquiggleEdgeSprite {
		get {
			return squiggleEdgeSprite;
		}
	}

	public Sprite OvalEdgeSprite {
		get {
			return ovalEdgeSprite;
		}
	}

	public Sprite DiamondEdgeSprite {
		get {
			return diamondEdgeSprite;
		}
	}

	public Sprite OpenShadingSprite {
		get {
			return openShadingSprite;
		}

		set {
			openShadingSprite = value;
		}
	}

	public Sprite StripedShadingSprite {
		get {
			return stripedShadingSprite;
		}

		set {
			stripedShadingSprite = value;
		}
	}

	public Sprite SolidShadingSprite {
		get {
			return solidShadingSprite;
		}

		set {
			solidShadingSprite = value;
		}
	}

	public Color RedColor {
		get {
			return redColor;
		}

		set {
			redColor = value;
		}
	}

	public Color GreenColor {
		get {
			return greenColor;
		}

		set {
			greenColor = value;
		}
	}

	public Color PurpleColor {
		get {
			return purpleColor;
		}

		set {
			purpleColor = value;
		}
	}

	private void Awake() {
		if(instance != null && instance != this)
			Debug.LogError("More than one IconContainer component was found.");

		instance = this;
	}

	public IconObject GetRandomIcon() {
		return icons[Random.Range(0, icons.Length - 1)];
	}
}
