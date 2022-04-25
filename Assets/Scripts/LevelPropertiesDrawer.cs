using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


[CustomPropertyDrawer(typeof(LevelProperties))]
public class LevelPropertiesDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var sizeRect = new Rect(position.x, position.y, 30, position.height);
        var colorRect = new Rect(position.x + 35, position.y, 50, position.height);
        EditorGUI.PropertyField(sizeRect, property.FindPropertyRelative("Size"), new GUIContent("Size"));
        EditorGUI.PropertyField(colorRect, property.FindPropertyRelative("MapColor"), new GUIContent("Color"));

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}