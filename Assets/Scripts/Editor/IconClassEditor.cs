using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IconClass))]
public class IconClassEditor : Editor {

	public override void OnInspectorGUI() {
		IconClass instance = target as IconClass;

		IconObject newIcon = EditorGUILayout.ObjectField("Icon", instance.Icon, typeof(IconObject), false) as IconObject;
		if(newIcon != null)
			instance.Icon = newIcon;

		Debug.Log(instance.Icon);

		base.OnInspectorGUI();
	}
}
