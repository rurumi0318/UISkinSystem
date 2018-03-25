using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Rotorz.ReorderableList;

namespace UISKin
{
	[CustomEditor(typeof(SkinModifier), true)]
	public class SkinModifierEditor : Editor
	{
		SerializedProperty selectorsProp;

		void OnEnable()
		{
			selectorsProp = serializedObject.FindProperty("selectors");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			ReorderableListGUI.Title("Selectors");
			ReorderableListGUI.ListField(selectorsProp);
			EditorGUILayout.Space();

			serializedObject.ApplyModifiedProperties();

			DrawDefaultInspector();
		}
	}
}