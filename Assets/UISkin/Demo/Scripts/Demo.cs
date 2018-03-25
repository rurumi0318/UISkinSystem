using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UISKin.Demo
{
	public class Demo : MonoBehaviour
	{
		[SerializeField]
		SkinManager skinManager;

		[SerializeField]
		SkinAsset[] skins;

		public void ChangeSkin()
		{
			if (skinManager.GetCurrentSkin() == skins[0])
			{
				skinManager.ChangeSkin(skins[1]);
			}
			else
			{
				skinManager.ChangeSkin(skins[0]);
			}
		}


		[Header("Other example")]
		[SerializeField]
		SkinManager speedManager;

		[SerializeField]
		SkinComponent rotatorSkin;

		bool toggleFlag;

		public void ChangeSpeed()
		{
			if (toggleFlag)
			{
				rotatorSkin.RemoveSelector("fast");
				rotatorSkin.AddSelector("slow");
			}
			else
			{
				rotatorSkin.RemoveSelector("slow");
				rotatorSkin.AddSelector("fast");
			}

			toggleFlag = !toggleFlag;
		}
	}
}