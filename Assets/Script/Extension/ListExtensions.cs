using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions 
{
    public static IList<T> Shuffle<T>(this IList<T> list)
	{
		int i = list.Count;
		while (i > 1)
		{
			i--;
			int index = UnityEngine.Random.Range(0, i + 1);
			T value = list[index];
			list[index] = list[i];
			list[i] = value;
		}
		return list;
	}

	public static void Resize<T>(this List<T> list, int size, T element = default(T))
	{
		int count = list.Count;
		if (size < count)
		{
			list.RemoveRange(size, count - size);
			return;
		}
		if (size > count)
		{
			if (size > list.Capacity)
			{
				list.Capacity = size;
			}
			list.AddRange(Enumerable.Repeat<T>(element, size - count));
		}
	}

	public static T PickRandom<T>(this IList<T> list)
	{
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public static T PickRandomWithWeights<T>(this List<T> list, IList<float> weights)
	{
		float max = weights.Sum();
		float num = UnityEngine.Random.Range(0f, max);
		int num2 = 0;
		float num3 = 0f;
		while (num2 < weights.Count && num3 + weights[num2] < num)
		{
			num3 += weights[num2];
			num2++;
		}
		if (num2 >= weights.Count)
		{
			Debug.LogWarning("Something went wrong...");
			return list[0];
		}
		return list[num2];
	}

	public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
	{
		TValue result;
		if (!dictionary.TryGetValue(key, out result))
		{
			return defaultValue;
		}
		return result;
	}

	public static void InsertAt<T>(this IList<T> list, int index, T element)
    {
        if (index < 0 || index > list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        list.Insert(index, element);
    }

    public static void RemoveAtIndex<T>(this IList<T> list, int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        list.RemoveAt(index);
    }

	public static string String<T>(this IList<T> list)
    {
        return string.Join(", ", list);
    }
}
