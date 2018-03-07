using UnityEngine;

[CreateAssetMenu]
public class IconObject : ScriptableObject {

	public enum Shading {
		solid = 0,
		striped = 1,
		open = 2
	}

	public enum Shape {
		diamond = 0,
		squiggle = 1,
		oval = 2
	}

	public enum Color {
		red = 0,
		green = 1,
		purple = 2
	}
	
	public Shading shading;
	public Shape shape;
	public Color color;
	public UnityEngine.Color imageColor = UnityEngine.Color.white;

	public static bool operator==(IconObject a, IconObject b) {
		if(Equals(a, null) || Equals(b, null))
			return false;

		return a.shading == b.shading || a.shape == b.shape || a.color == b.color;
	}

	public static bool operator!=(IconObject a, IconObject b) {
		if(Equals(a, null) || Equals(b, null))
			return false;

		return a.shading != b.shading && a.shape != b.shape && a.color != b.color;
	}

	public override bool Equals(object obj) {
		IconObject icon = obj as IconObject;
		return icon != null &&
			   shading == icon.shading ||
			   shape == icon.shape ||
			   color == icon.color;
	}

	public static bool SetEquals(IconObject a, IconObject b, IconObject c) {
		if(Equals(a, null) || Equals(b, null) || Equals(c, null))
			return false;

		// One property the same
		if(a.shading == b.shading && b.shading == c.shading)
			return true;

		if(a.shape == b.shape && b.shape == c.shape)
			return true;

		if(a.color == b.color && b.color == c.color)
			return true;
		
		// All unique
		if(a != b && b != c)
			return true;

		return false;
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
