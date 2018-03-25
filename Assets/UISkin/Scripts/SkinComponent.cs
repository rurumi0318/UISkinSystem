using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UISKin
{
	[ExecuteInEditMode]
	public class SkinComponent : MonoBehaviour
	{
		[SerializeField]
		SkinManager skinManager;

		[SerializeField]
		string[] selectors;

		public string[] GetSelectors()
		{
			return selectors;
		}

		public void ToggleSelector(string selector)
		{
			if (System.Array.IndexOf(selectors, selector) >= 0)
			{
				RemoveSelector(selector);
			}
			else
			{
				AddSelector(selector);
			}
		}

		public void AddSelector(string selector)
		{
			if (System.Array.IndexOf(selectors, selector) < 0)
			{
				System.Array.Resize<string>(ref selectors, selectors.Length + 1);
				selectors[selectors.Length - 1] = selector;
			}

			if (skinManager != null)
			{
				skinManager.ApplyTo(this);
			}
		}

		public void RemoveSelector(string selector)
		{
			var list = new List<string>(selectors);
			list.Remove(selector);

			selectors = list.ToArray();

			if (skinManager != null)
			{
				skinManager.ApplyTo(this);
			}
		}

		void OnEnable()
		{
			if (skinManager != null)
			{
				skinManager.Register(this);
			}
		}

		void OnDisable()
		{
			if (skinManager != null)
			{
				skinManager.Unregister(this);
			}
		}
	}
}
