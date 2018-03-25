using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fields;
using System;

namespace UISKin
{
	[CreateAssetMenu(fileName = "ImageModifier", menuName = "UISkin/ImageModifier")]
	public class SkinModifierImage : SkinModifier
	{
		[SerializeField]
		ColorField color;

		[SerializeField]
		Sprite sprite;

		public override bool CanApplyTo(SkinComponent skinComponent)
		{
			return skinComponent.GetComponent<Image>() != null;
		}

		public override void ApplyTo(SkinComponent skinComponent)
		{
			var image = skinComponent.GetComponent<Image>();

			if (color != null)
			{
				image.color = color.GetValue();
			}

			if (sprite != null)
			{
				image.sprite = sprite;
			}
		}
	}
}