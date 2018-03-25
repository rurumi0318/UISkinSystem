using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Rotorz.ReorderableList;

namespace UISKin
{
	[CustomEditor(typeof(SkinAsset))]
	public class SkinAssetEditor : Editor
	{
		SerializedProperty modifiersProp;

		void OnEnable()
		{
			modifiersProp = serializedObject.FindProperty("modifiers");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			ReorderableListGUI.Title("Modifiers");
			ReorderableListGUI.ListField(modifiersProp);

			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(modifiersProp, true);
			

			serializedObject.ApplyModifiedProperties();
		}
	}
}