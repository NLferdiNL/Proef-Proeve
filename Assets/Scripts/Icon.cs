using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Icon : ScriptableObject {

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

	public enum Amount {
		one = 0,
		two = 1,
		three = 2
	}

	public Shading shading;
	public Shape shape;
	public Color color;
	public Amount amount;
	public Texture texture;

	public static bool operator==(Icon a, Icon b) {
		if (a == null || b == null)
			return false;

		return a.shading == b.shading || a.shape == b.shape || a.color == b.color || a.amount == b.amount;
	}

	public static bool operator!=(Icon a, Icon b) {
		if (a == null || b == null)
			return true;

		return a.shading != b.shading && a.shape != b.shape && a.color != b.color && a.amount != b.amount;
	}

	public override bool Equals(object obj) {
		Icon icon = obj as Icon;
		return icon != null &&
			   shading == icon.shading ||
			   shape == icon.shape ||
			   color == icon.color ||
			   amount == icon.amount;
	}

	public override int GetHashCode() {
		var hashCode = 1884107072;
		hashCode = hashCode * -1521134295 + base.GetHashCode();
		hashCode = hashCode * -1521134295 + shading.GetHashCode();
		hashCode = hashCode * -1521134295 + shape.GetHashCode();
		hashCode = hashCode * -1521134295 + color.GetHashCode();
		hashCode = hashCode * -1521134295 + amount.GetHashCode();
		return hashCode;
	}
}
