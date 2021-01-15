using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CharacterStat))]
public class StatPropertyDrawer : PropertyDrawer
{
	STATTYPE type;
	SerializedProperty baseValue;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		type = (STATTYPE)property.FindPropertyRelative("_type").enumValueIndex;
		baseValue = property.FindPropertyRelative("_baseValue");

		Rect right = new Rect(position.x + position.width / 3.0f,
			position.y,
			position.width / 3.0f,
			position.height);

		GUI.Label(position, type.ToString());
		EditorGUI.PropertyField(right, baseValue, GUIContent.none);
	}
}
