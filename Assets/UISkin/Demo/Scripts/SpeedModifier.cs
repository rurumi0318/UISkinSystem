using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fields;
using System;

namespace UISKin.Demo
{
	[CreateAssetMenu(fileName = "RotationSpeed", menuName = "Demo/RotationSpeed")]
	public class SpeedModifier : SkinModifier
	{
		[SerializeField]
		FloatField xSpeed, ySpeed, zSpeed;

		public override bool CanApplyTo(SkinComponent skinComponent)
		{
			return skinComponent.GetComponent<AutoRotate>() != null;
		}

		public override void ApplyTo(SkinComponent skinComponent)
		{
			var rotate = skinComponent.GetComponent<AutoRotate>();
			rotate.xAngle = xSpeed;
			rotate.yAngle = ySpeed;
			rotate.zAngle = zSpeed;
		}
	}
}