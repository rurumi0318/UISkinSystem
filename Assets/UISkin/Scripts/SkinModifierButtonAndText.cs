using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fields;
using System;

namespace UISKin
{
	[CreateAssetMenu(fileName = "ButtonTextModifier", menuName = "UISkin/ButtonTextModifier")]
	public class SkinModifierButtonAndText : SkinModifier
	{
		[SerializeField]
		ColorBlockField colors;

		[SerializeField]
		FloatField fontSize;

		[SerializeField]
		ColorField fontColor;

		[SerializeField]
		Font font;

		[SerializeField]
		FontStyle fontStyle = FontStyle.Normal;

		public override bool CanApplyTo(SkinComponent skinComponent)
		{
			return skinComponent.GetComponent<Button>() != null;
		}

		public override void ApplyTo(SkinComponent skinComponent)
		{
			var button = skinComponent.GetComponent<Button>();
			button.colors = colors.GetValue();

			var text = skinComponent.GetComponentInChildren<Text>();
			if (text != null)
			{
				if (fontSize != null)
				{
					text.fontSize = (int)fontSize.GetValue();
				}

				if (fontColor != null)
				{
					text.color = fontColor.GetValue();
				}

				if (font != null)
				{
					text.font = font;
				}

				text.fontStyle = fontStyle;
			}
		}
	}
}