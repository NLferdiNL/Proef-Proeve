using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class IconClass : MonoBehaviour {

	public enum Amount {
		one = 1,
		two = 2,
		three = 3
	}

	private IconObject icon;

	[SerializeField]
	Amount amount;

	[SerializeField]
	Image edgeMask, inner, visibleEdge;

	public IconObject.Shading shading {
		get {
			return icon.shading;
		}
	}

	public IconObject.Shape shape {
		get {
			return icon.shape;
		}
	}

	public IconObject.Color color {
		get {
			return icon.color;
		}
	}

	public IconObject Icon {
		get {
			return icon;
		}

		set {
			UpdateSprites();
			icon = value;
		}
	}

	public void UpdateSprites() {
		Sprite newSprite = null;

		switch(shape) {
			case IconObject.Shape.diamond:
				newSprite = IconContainer.Instance.DiamondEdgeSprite;
				break;
			case IconObject.Shape.oval:
				newSprite = IconContainer.Instance.OvalEdgeSprite;
				break;
			case IconObject.Shape.squiggle:
				newSprite = IconContainer.Instance.SquiggleEdgeSprite;
				break;
		}

		edgeMask.sprite = visibleEdge.sprite = newSprite;
		newSprite = null;

		switch(shading) {
			case IconObject.Shading.open:
				newSprite = IconContainer.Instance.OpenShadingSprite;
				break;
			case IconObject.Shading.solid:
				newSprite = IconContainer.Instance.SolidShadingSprite;
				break;
			case IconObject.Shading.striped:
				newSprite = IconContainer.Instance.StripedShadingSprite;
				break;
		}

		inner.sprite = newSprite;

		Color newColor = Color.white;

		switch(color) {
			case IconObject.Color.green:
				newColor = IconContainer.Instance.GreenColor;
				break;
			case IconObject.Color.purple:
				newColor = IconContainer.Instance.PurpleColor;
				break;
			case IconObject.Color.red:
				newColor = IconContainer.Instance.RedColor;
				break;
		}

		visibleEdge.color = inner.color = newColor;
	}

	public static bool operator ==(IconClass a, IconClass b) {
		if(Equals(a, null) || Equals(b, null))
			return false;

		return a.shading == b.shading || a.shape == b.shape || a.color == b.color || a.amount == b.amount;
	}

	public static bool operator !=(IconClass a, IconClass b) {
		if(Equals(a, null) || Equals(b, null))
			return false;

		return a.shading == b.shading || a.shape == b.shape || a.color == b.color || a.amount == b.amount;
	}

	public static bool SetEquals(IconClass a, IconClass b, IconClass c) {
		if(Equals(a, null) || Equals(b, null) || Equals(c, null))
			return false;

		// One property the same
		if(a.shading == b.shading && b.shading == c.shading)
			return true;

		if(a.shape == b.shape && b.shape == c.shape)
			return true;

		if(a.color == b.color && b.color == c.color)
			return true;

		if(a.amount == b.amount && b.amount == c.amount)
			return true;

		// All unique
		if(a != b && b != c)
			return true;

		return false;
	}

	public override bool Equals(object obj) {
		IconClass icon = obj as IconClass;
		return icon != null &&
			   shading == icon.shading ||
			   shape == icon.shape ||
			   color == icon.color;
	}

	public override int GetHashCode() {
		var hashCode = 1884107072;
		hashCode = hashCode * -1521134295 + base.GetHashCode();
		hashCode = hashCode * -1521134295 + shading.GetHashCode();
		hashCode = hashCode * -1521134295 + shape.GetHashCode();
		hashCode = hashCode * -1521134295 + color.GetHashCode();
		return hashCode;
	}
}
