using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(LevelProperties))]
public class LevelPropertiesDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        
        var sizeRect = new Rect(position.x, position.y + 20, position.width, position.height / 5);
        var colorRect = new Rect(position.x, position.y + 40, position.width, position.height / 5);
        var buttonRect = new Rect(position.x, position.y + 70, position.width, position.height / 5);


        EditorGUI.PropertyField(sizeRect, property.FindPropertyRelative("Size"), new GUIContent("Size"));
        EditorGUI.PropertyField(colorRect, property.FindPropertyRelative("MapColor"), new GUIContent("Color"));
        if (GUI.Button(buttonRect, "Create Map"))
        {
            LevelManager.Instance.GenerateMap();
        }


        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 5.0f;
    }
}