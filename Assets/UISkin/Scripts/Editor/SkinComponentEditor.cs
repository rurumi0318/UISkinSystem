using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace UISKin
{
	[CustomEditor(typeof(SkinComponent))]
	public class SkinComponentEditor : Editor
	{
		SkinComponent targetComponent;
		SerializedProperty managerProp;

		void OnEnable()
		{
			targetComponent = (SkinComponent)target;
			managerProp = serializedObject.FindProperty("skinManager");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			SkinManager manager = managerProp.objectReferenceValue as SkinManager;

			EditorGUI.BeginChangeCheck();

			EditorGUILayout.PropertyField(managerProp, new GUIContent("SkinManager"));

			if (EditorGUI.EndChangeCheck())
			{
				if (manager != null)
				{
					manager.Unregister(targetComponent);
				}

				manager = managerProp.objectReferenceValue as SkinManager;

				if (manager != null)
				{
					manager.Register(targetComponent);
				}

				serializedObject.ApplyModifiedProperties();
			}

			if (manager == null)
			{
				return;
			}

			// list selectors
			EditorGUILayout.Separator();

			if (GUILayout.Button("Change Selectors"))
			{
				RenderGenericMenu(manager);
			}

			RenderSelectors();
			RenderAppliedModifiers(manager);
		}

		void RenderGenericMenu(SkinManager skinManager)
		{
			GenericMenu menu = new GenericMenu();

			var possibleSelectors = skinManager.GetPossibleSelectors(targetComponent);
			var selectors = targetComponent.GetSelectors();

			// remove redundant selectors
			for (int i = selectors.Length - 1; i >= 0; i--)
			{
				if (possibleSelectors.Contains(selectors[i]) == false)
				{
					targetComponent.RemoveSelector(selectors[i]);
				}
			}

			for (int i = 0; i < possibleSelectors.Count; i++)
			{
				var selected = System.Array.IndexOf(selectors, possibleSelectors[i]) >= 0;
				menu.AddItem(new GUIContent(possibleSelectors[i]), selected, OnItemSelected, possibleSelectors[i]);
			}

			menu.ShowAsContext();
		}

		void OnItemSelected(object selector)
		{
			targetComponent.ToggleSelector((string)selector);
			EditorUtility.SetDirty(target);
			EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
		}

		void RenderSelectors()
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Selectors:");

			var selectors = targetComponent.GetSelectors();

			EditorGUILayout.BeginVertical();
			for (int i = 0; i < selectors.Length; i++)
			{
				EditorGUILayout.BeginHorizontal();

				if (GUILayout.Button("X", GUILayout.Width(30f)))
				{
					OnItemSelected(selectors[i]);
					break;
				}

				EditorGUILayout.LabelField(selectors[i]);
				
				EditorGUILayout.EndHorizontal();
			}
			EditorGUILayout.EndVertical();
		}

		void RenderAppliedModifiers(SkinManager skinManager)
		{
			EditorGUILayout.Space();
			EditorGUILayout.LabelField("Applied Modifiers:");

			var appliedModifiers = skinManager.GetAppliedModifiers(targetComponent);

			EditorGUILayout.BeginVertical();
			for (int i = 0; i < appliedModifiers.Count; i++)
			{
				var assetPath = AssetDatabase.GetAssetPath(appliedModifiers[i]);
				var fileName = System.IO.Path.GetFileName(assetPath);
				if (GUILayout.Button(fileName))
				{
					EditorGUIUtility.PingObject(appliedModifiers[i]);
				}
			}
			EditorGUILayout.EndVertical();
		}
	}
}