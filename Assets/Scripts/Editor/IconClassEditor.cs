using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IconClass))]
public class IconClassEditor : Editor {

	public override void OnInspectorGUI() {
		IconClass instance = target as IconClass;

		instance.Icon = EditorGUILayout.ObjectField("Icon", instance.Icon, typeof(IconObject), false) as IconObject;

		base.OnInspectorGUI();
	}
}
