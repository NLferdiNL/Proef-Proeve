using System.Collections.Generic;
using UnityEngine;

public class IconAssetData : MonoBehaviour {

	public class IconData {

		private int amount = 1;
		private Sprite sprite;
		private Color color;

		public IconData(int amount, Sprite sprite, Color color) {
			this.amount = amount;
			this.sprite = sprite;
			this.color = color;
		}

		public Color Color {
			get {
				return color;
			}
		}

		public Sprite Sprite {
			get {
				return sprite;
			}
		}

		public int Amount {
			get {
				return amount;
			}
		}

		public static bool operator==(IconData a, IconData b) {
			if(Equals(a, null) || Equals(b, null))
				return false;

			return a.Color == b.Color || a.Sprite == b.Sprite || a.Amount == b.Amount;
		}

		public static bool operator!=(IconData a, IconData b) {
			if(Equals(a, null) || Equals(b, null))
				return false;

			return a.Color != b.Color && a.Sprite != b.Sprite && a.Amount != b.Amount;
		}

		public static bool Set(IconData a, IconData b, IconData c) {
			if(a.color == b.color && b.color == c.color)
				return true;

			if(a.sprite == b.sprite && b.sprite == c.sprite)
				return true;
			
			if(a.amount == b.amount && b.amount == c.amount)
				return true;
			
			if(a != b && a != c && b != c)
				return true;

			return false;
		}

		public override bool Equals(object obj) {
			var data = obj as IconData;
			return data != null &&
				   EqualityComparer<Color>.Default.Equals(Color, data.Color) &&
				   EqualityComparer<Sprite>.Default.Equals(Sprite, data.Sprite) &&
				   Amount == data.Amount;
		}

		public override int GetHashCode() {
			var hashCode = -754422659;
			hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(Color);
			hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(Sprite);
			hashCode = hashCode * -1521134295 + Amount.GetHashCode();
			return hashCode;
		}
	}

	[SerializeField]
	List<IconData> iconObjects;

	static IconAssetData instance;

	public static IconAssetData Instance {
		get {
			if(instance == null)
				instance = FindObjectOfType<IconAssetData>();

			return instance;
		}
	}

	/*[SerializeField]
	private Sprite squiggleEdgeSprite;

	[SerializeField]
	private Sprite ovalEdgeSprite;

	[SerializeField]
	private Sprite diamondEdgeSprite;*/

	[SerializeField]
	private Sprite openShadingSprite;

	[SerializeField]
	private Sprite stripedShadingSprite;

	[SerializeField]
	private Sprite solidShadingSprite;

	//[SerializeField]
	//private Color redColor = Color.red;

	//[SerializeField]
	//private Color greenColor = Color.green;

	//[SerializeField]
	//private Color purpleColor = Color.magenta;

	[SerializeField]
	GameObject iconPrefab;

	[SerializeField]
	int iconsInCircle = 9;

	[SerializeField]
	Color[] symbolColors = new Color[3] {
		Color.red,
		Color.green,
		Color.magenta
	};

	[SerializeField]
	Sprite[] symbolSprites;

	/*public Sprite SquiggleEdgeSprite {
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
	}*/

	public Sprite OpenShadingSprite {
		get {
			return openShadingSprite;
		}
	}

	public Sprite StripedShadingSprite {
		get {
			return stripedShadingSprite;
		}
	}

	public Sprite SolidShadingSprite {
		get {
			return solidShadingSprite;
		}
	}

	/*public Color RedColor {
		get {
			return redColor;
		}
	}

	public Color GreenColor {
		get {
			return greenColor;
		}
	}

	public Color PurpleColor {
		get {
			return purpleColor;
		}
	}*/

	public GameObject IconPrefab {
		get {
			return iconPrefab;
		}
	}

	public int IconsInCircle {
		get {
			return iconsInCircle;
		}
	}

	private void Awake() {
		if(instance != null && instance != this)
			Debug.LogError("More than one IconContainer component was found.");

		instance = this;
	}

	IconData GenerateIconData() {
		IconData iconData = new IconData(Random.Range(1,4), symbolSprites[Random.Range(0, symbolSprites.Length)], symbolColors[Random.Range(0, symbolColors.Length)]);

		if(Array.IndexOf(iconObjects, iconData) == -1)
			return iconData;
		else
			return GenerateIconData();
	}

	public IconData GetRandomIcon() {
		IconData toReturn = GenerateIconData();
		iconObjects.Add(toReturn);
		return toReturn;
	}
}
