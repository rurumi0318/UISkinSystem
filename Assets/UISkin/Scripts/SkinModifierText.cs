using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fields;

namespace UISKin
{
	[CreateAssetMenu(fileName = "TextModifier", menuName = "UISkin/TextModifier")]
	public class SkinModifierText : SkinModifier
	{
		[SerializeField]
		FloatField fontSize;

		[SerializeField]
		ColorField color;

		[SerializeField]
		Font font;

		[SerializeField]
		FontStyle fontStyle = FontStyle.Normal;

		public override bool CanApplyTo(SkinComponent skinComponent)
		{
			return skinComponent.GetComponent<Text>() != null;
		}

		public override void ApplyTo(SkinComponent skinComponent)
		{
			var textComponent = skinComponent.GetComponent<Text>();

			if (fontSize != null)
			{
				textComponent.fontSize = (int)fontSize.GetValue();
			}

			if (color != null)
			{
				textComponent.color = color.GetValue();
			}

			if (font != null)
			{
				textComponent.font = font;
			}

			textComponent.fontStyle = fontStyle;
		}
	}
}