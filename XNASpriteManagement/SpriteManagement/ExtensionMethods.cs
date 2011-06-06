using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace XNASpriteManagement
{
	public static partial class ExtensionMethods
	{
		/// <summary>
		/// http://stackoverflow.com/questions/654441/extension-methods-dictionarytkey-tvalue-removeall-is-it-possible
		/// </summary>
		public static void RemoveAll<TKey, TValue>(this SortedDictionary<TKey, TValue> dict,
									 Func<KeyValuePair<TKey, TValue>, bool> condition)
		{
			foreach (var cur in dict.Where(condition).ToList())
			{
				dict.Remove(cur.Key);
			}
		}
	}
}