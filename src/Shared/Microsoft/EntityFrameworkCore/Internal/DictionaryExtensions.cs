using JetBrains.Annotations;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.EntityFrameworkCore.Internal
{
	[DebuggerStepThrough]
	internal static class DictionaryExtensions
	{
		public static TValue GetOrAddNew<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> source, [NotNull] TKey key) where TValue : new()
		{
			if (!source.TryGetValue(key, out TValue value))
			{
				value = new TValue();
				source.Add(key, value);
			}
			return value;
		}

		public static TValue Find<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> source, [NotNull] TKey key)
		{
			if (source.TryGetValue(key, out TValue value))
			{
				return value;
			}
			return default;
		}
	}
}
