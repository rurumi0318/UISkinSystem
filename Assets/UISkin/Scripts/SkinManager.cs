using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UISKin
{
	[ExecuteInEditMode]
	[CreateAssetMenu(fileName = "SkinManager", menuName = "UISkin/SkinManager")]
	public class SkinManager : ScriptableObject
	{
		[SerializeField]
		SkinAsset currentSkin;

		List<SkinComponent> skinComponents = new List<SkinComponent>();

		public SkinAsset GetCurrentSkin()
		{
			return currentSkin;
		}

		public void Register(SkinComponent skinComponent)
		{
			if (skinComponents.Contains(skinComponent) == false)
			{
				skinComponents.Add(skinComponent);
			}

			ApplyTo(skinComponent);
		}

		public void Unregister(SkinComponent skinComponent)
		{
			skinComponents.Remove(skinComponent);
		}

		public void ApplyTo(SkinComponent skinComponent)
		{
			if (currentSkin == null)
			{
				return;
			}

			var modifiers = currentSkin.GetModifiers();
			if (modifiers == null || modifiers.Length == 0)
			{
				return;
			}

			for (int i = 0; i < modifiers.Length; i++)
			{
				var modifier = modifiers[i];

				if (modifier == null)
				{
					continue;
				}

				if (modifier.CanMatchSelector(skinComponent) && modifier.CanApplyTo(skinComponent))
				{
					modifier.ApplyTo(skinComponent);
				}
			}
		}

		public void ChangeSkin(SkinAsset newSkinAsset)
		{
			currentSkin = newSkinAsset;
			NotifySkinChange();
		}

		public List<SkinComponent> NotifySkinChange()
		{
			List<SkinComponent> affected = new List<SkinComponent>();

			for (int i = skinComponents.Count - 1; i >= 0; i--)
			{
				if (skinComponents[i] == null)
				{
					skinComponents.RemoveAt(i);
					continue;
				}

				ApplyTo(skinComponents[i]);

				affected.Add(skinComponents[i]);
			}

			return affected;
		}

		public List<SkinModifier> GetAppliedModifiers(SkinComponent skinComponent)
		{
			List<SkinModifier> result = new List<SkinModifier>();
			if (currentSkin == null)
			{
				return result;
			}

			var modifiers = currentSkin.GetModifiers();
			if (modifiers == null || modifiers.Length == 0)
			{
				return result;
			}

			for (int i = 0; i < modifiers.Length; i++)
			{
				var modifier = modifiers[i];
				if (modifier == null)
				{
					continue;
				}

				if (modifier.CanMatchSelector(skinComponent) && modifier.CanApplyTo(skinComponent))
				{
					result.Add(modifier);
				}
			}

			return result;
		}

		public List<string> GetPossibleSelectors(SkinComponent skinComponent)
		{
			List<string> result = new List<string>();

			if (currentSkin == null)
			{
				return result;
			}

			var modifiers = currentSkin.GetModifiers();
			if (modifiers == null)
			{
				return result;
			}

			for (int i = 0; i < modifiers.Length; i++)
			{
				var modifier = modifiers[i];
				if (modifier == null)
				{
					continue;
				}

				if (modifier.CanApplyTo(skinComponent))
				{
					var selectors = modifier.GetSelectors();
					if (selectors == null)
					{
						continue;
					}

					foreach (var selector in selectors)
					{
						if (selector != null && result.Contains(selector) == false)
						{
							result.Add(selector);
						}
					}
				}
			}


			return result;
		}
	}
}