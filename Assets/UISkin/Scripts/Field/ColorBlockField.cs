using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fields
{
	[CreateAssetMenu(fileName = "ColorBlockField", menuName = "Fields/ColorBlockField")]
	public class ColorBlockField : ScriptableObject
	{
		[SerializeField]
		ColorBlock colorBlockValue = ColorBlock.defaultColorBlock;

		public ColorBlock GetValue()
		{
			return colorBlockValue;
		}
	}
}