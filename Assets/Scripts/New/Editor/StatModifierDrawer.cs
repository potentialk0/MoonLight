using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(StatModifier))]
public class StatModifierDrawer : PropertyDrawer
{
	STATTYPE type;
	SerializedProperty value;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		type = (STATTYPE)property.FindPropertyRelative("_type").enumValueIndex;
		value = property.FindPropertyRelative("_value");

		Rect right = new Rect(position.x + position.width / 3.0f,
			position.y,
			position.width / 3.0f,
			position.height);

		GUI.Label(position, type.ToString());
		EditorGUI.PropertyField(right, value, GUIContent.none);
	}
}
