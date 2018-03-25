using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fields
{
	[CreateAssetMenu(fileName = "ColorField", menuName = "Fields/ColorField")]
	public class ColorField : ScriptableObject
	{
		[SerializeField]
		Color colorValue = Color.white;

		public Color GetValue()
		{
			return colorValue;
		}
	}
}