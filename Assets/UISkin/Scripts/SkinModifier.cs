using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UISKin
{
	public abstract class SkinModifier : ScriptableObject
	{
		protected enum SelectorMatchMehod
		{
			All,            // skinComponent selectors cover all selectors of this modifier
			Any,            // skinComponent selectors match any selectors of this modifier
			ExactlySame     // skinComponent selectors are exactly same as selectors of this modifier
		}

		// just for editor, inspector
		[SerializeField]
		string comment;

		[HideInInspector]
		[SerializeField]
		string[] selectors;

		[SerializeField]
		protected SelectorMatchMehod matchMethod = SelectorMatchMehod.All;

		public abstract bool CanApplyTo(SkinComponent skinComponent);
		public abstract void ApplyTo(SkinComponent skinComponent);

		public string[] GetSelectors()
		{
			return selectors;
		}

		public virtual bool CanMatchSelector(SkinComponent skinComponent)
		{
			var otherSelectors = skinComponent.GetSelectors();
			if (otherSelectors == null || otherSelectors.Length == 0)
			{
				return false;
			}

			if (selectors == null || selectors.Length == 0)
			{
				return false;
			}

			switch (matchMethod)
			{
				case SelectorMatchMehod.Any:
					return IsMatchAnySelector(otherSelectors);

				case SelectorMatchMehod.ExactlySame:
					return IsMatchExactlySameSelector(otherSelectors);

				case SelectorMatchMehod.All:
				default:
					return IsMatchAllSelector(otherSelectors);
			}
		}

		protected bool IsMatchAnySelector(string[] otherSelector)
		{
			foreach (var selector in selectors)
			{
				if (Array.IndexOf(otherSelector, selector) >= 0)
				{
					return true;
				}
			}

			return false;
		}

		protected bool IsMatchAllSelector(string[] otherSelector)
		{
			foreach (var selector in selectors)
			{
				if (Array.IndexOf(otherSelector, selector) < 0)
				{
					return false;
				}
			}
			return true;
		}

		protected bool IsMatchExactlySameSelector(string[] otherSelector)
		{
			if (selectors.Length != otherSelector.Length)
			{
				return false;
			}

			return IsMatchAllSelector(otherSelector);
		}
	}
}