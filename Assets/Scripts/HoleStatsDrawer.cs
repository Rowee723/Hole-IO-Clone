using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


[CustomPropertyDrawer(typeof(int))]
public class HoleStatsDrawer : PropertyDrawer
{
    /*
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var Name = new PropertyField(property.FindPropertyRelative("Name"));
        var Points = new PropertyField(property.FindPropertyRelative("Points"));

        container.Add(Name);
        container.Add(Points);

        return container;
    }
    */

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        GUI.backgroundColor = Color.red;
        EditorGUI.PropertyField(position, property, GUIContent.none);

        EditorGUI.EndProperty();

    }
}
