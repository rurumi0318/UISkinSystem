using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fields
{
	[CreateAssetMenu(fileName = "FloatField", menuName = "Fields/FloatField")]
	public class FloatField : ScriptableObject
	{
		[SerializeField]
		float floatValue = 0f;

		public float GetValue()
		{
			return floatValue;
		}
	}
}