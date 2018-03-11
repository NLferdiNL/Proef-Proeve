using System;
using System.Collections.Generic;
using UnityEngine;

public class IconAssetData : MonoBehaviour {

	public class IconData {

		public enum Shading {
			Open = 0,
			Striped = 1,
			Solid = 2
		} 

		private int amount = 1;
		private Sprite sprite;
		private Color color;
		private Shading shading;

		public IconData(int amount, Sprite sprite, Shading shading, Color color) {
			this.amount = amount;
			this.sprite = sprite;
			this.shading = shading;
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

		public Shading _Shading {
			get {
				return shading;
			}
		}

		public static bool operator==(IconData a, IconData b) {
			if(Equals(a, null) || Equals(b, null))
				return false;
			
			return a.Color == b.Color && a.Sprite == b.Sprite && a.Amount == b.Amount && a._Shading == b._Shading;
		}

		public static bool operator!=(IconData a, IconData b) {
			if(Equals(a, null) || Equals(b, null))
				return false;

			return a.Color != b.Color && a.Sprite != b.Sprite && a.Amount != b.Amount && a._Shading != b._Shading;
		}

		public static bool Set(IconData a, IconData b, IconData c) {
			bool currentStatus = false;

			if(a.Color == b.Color && b.Color == c.Color)
				currentStatus = true;
			else if(a.Color != b.Color && a.Color != c.Color && b.Color != c.Color)
				currentStatus = true;
			else
				return false;

			if(a.Sprite == b.Sprite && b.Sprite == c.Sprite)
				currentStatus = true;
			else if(a.Sprite != b.Sprite && b.Sprite != c.Sprite && a.Sprite != c.Sprite)
				currentStatus = true;
			else
				return false;

			if(a.Amount == b.Amount && b.Amount == c.Amount)
				currentStatus = true;
			else if(a.Amount != b.Amount && b.Amount != c.Amount && a.Amount != c.Amount)
				currentStatus = true;
			else
				return false;

			if(a._Shading == b._Shading && b._Shading == c._Shading)
				currentStatus = true;
			else if(a._Shading != b._Shading && b._Shading != c._Shading && a._Shading != c._Shading)
				currentStatus = true;
			else
				return false;

			if(a != b && a != c && b != c)
				currentStatus = true;

			return currentStatus;
		}

		public override bool Equals(object obj) {
			var data = obj as IconData;
			return data != null &&
				   color == data.Color &&
				   sprite == data.Sprite &&
				   amount == data.Amount &&
				   shading == data._Shading;
		}

		public override int GetHashCode() {
			var hashCode = -754422659;
			hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(Color);
			hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(Sprite);
			hashCode = hashCode * -1521134295 + Amount.GetHashCode();
			hashCode = hashCode * -1521134295 + Amount.GetHashCode();
			return hashCode;
		}
	}

	[SerializeField]
	List<IconData> iconObjects = new List<IconData>();

	static IconAssetData instance;

	public static IconAssetData Instance {
		get {
			if(instance == null)
				instance = FindObjectOfType<IconAssetData>();

			return instance;
		}
	}
	
	[SerializeField]
	private Sprite openShadingSprite;

	[SerializeField]
	private Sprite stripedShadingSprite;

	[SerializeField]
	private Sprite solidShadingSprite;
	
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
		IconData.Shading shading = IconData.Shading.Open;

		switch(UnityEngine.Random.Range(0, 4)) {
			case 0:
				shading = IconData.Shading.Open;
				break;
			case 1:
				shading = IconData.Shading.Striped;
				break;
			case 2:
				shading = IconData.Shading.Solid;
				break;
		}

		IconData iconData = new IconData(0, symbolSprites[UnityEngine.Random.Range(0, symbolSprites.Length)], shading, symbolColors[UnityEngine.Random.Range(0, symbolColors.Length)]);

		if(!IconExists(iconData)) {
			iconObjects.Add(iconData);
			return iconData;
		} else {
			return GenerateIconData();
		}
	}

	bool IconExists(IconData icon) {
		for(int i = 0; i < iconObjects.Count; i++) {
			IconData other = iconObjects[i];

			if(icon == other)
				return true;
		}

		return false;
	}

	public IconData GetRandomIcon() {
		IconData toReturn = GenerateIconData();
		return toReturn;
	}
}
