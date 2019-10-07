﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Deltatre.Utils.Types
{
  /// <inheritdoc />
	/// <summary>
	/// This type represents a non empty sequence of items
	/// </summary>
	/// <typeparam name="T">The type of items contained into the sequence</typeparam>
	public sealed class NonEmptySequence<T>: IEnumerable<T>
	{
		private readonly T[] _items;

    /// <summary>
    /// Initializes a new instance of the <see cref="NonEmptySequence{T}"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException">Throws ArgumentNullException when <paramref name="items"/> is null</exception>
    /// <exception cref="ArgumentException">Throws ArgumentException when <paramref name="items"/> is an empty sequence</exception>
    public NonEmptySequence(IEnumerable<T> items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items));

			var itemsArray = items.ToArray();

			if (itemsArray.Length == 0)
				throw new ArgumentException($"Parameter '{nameof(items)}' cannot be an empty sequence.");

			_items = itemsArray;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>) _items).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
	}
}
