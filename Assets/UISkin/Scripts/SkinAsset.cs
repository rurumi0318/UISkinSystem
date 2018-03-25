using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UISKin
{
	[CreateAssetMenu(fileName = "SkinAsset", menuName = "UISkin/SkinAsset")]
	public class SkinAsset : ScriptableObject
	{
		[SerializeField]
		SkinModifier[] modifiers;

		public SkinModifier[] GetModifiers()
		{
			return modifiers;
		}
	}
}