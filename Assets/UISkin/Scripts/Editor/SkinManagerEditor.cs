using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UISKin
{
	[CustomEditor(typeof(SkinManager))]
	public class SkinManagerEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUILayout.Space();
			if (GUILayout.Button("Notify Skin Change"))
			{
				var affected = ((SkinManager)target).NotifySkinChange();

				foreach(var skinComponent in affected)
				{
					EditorUtility.SetDirty(skinComponent);
				}
			}
		}
	}
}