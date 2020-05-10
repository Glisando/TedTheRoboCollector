using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortedList<T> where T:IComparable
{
    List<T> items = new List<T>();
    List<T> tempList;
	
    #region Constructors

    public SortedList()
    {
    }

    #endregion

    #region Properties

    public int Count
    {
        get { return items.Count; }
    }
	
    public T this[int index]
    {
        get { return items[index]; }
    }

    #endregion

    #region Methods

    public void Add(T item)
    {
        bool added = false;

        if (item == null)
            throw new ArgumentException("Null argument.");

        if (items.Count > 0 && items[items.Count - 1].CompareTo(item) >= 0)
            items.Add(item);
        else if (items.Count == 0)
            items.Add(item);
        else
        { 
            tempList = new List<T>();

            foreach(T i in items)
            {
                if (!added && i.CompareTo(item) <= 0)
                {
                    tempList.Add(item);
                    tempList.Add(i);
                    added = true;
                }
                else
                {
                    tempList.Add(i);
                }
            }

            items = tempList;
        }
    }

    public void RemoveAt(int index)
    {
        items.RemoveAt(index);
    }

    public void Remove(T itemToRemove)
    {
        int i = 0;

        while (i < items.Count)
        {
            if (items[i].CompareTo(itemToRemove) == 0)
            {
                break;   
            }
            i++;
        }

        items.RemoveAt(i);
    }

    public int IndexOf(T item)
    {
        int lowerBound = 0;
        int upperBound = items.Count - 1;
        int location = -1;

        while ((location == -1) &&
            (lowerBound <= upperBound))
        {
            int middleLocation = lowerBound + (upperBound - lowerBound) / 2;
            T middleValue = items[middleLocation];

            if (middleValue.CompareTo(item) == 0)
            {
                location = middleLocation;
            }
            else
            {
                if (middleValue.CompareTo(item) > 0)
                {
                    upperBound = middleLocation - 1;
                }
                else
                {
                    lowerBound = middleLocation + 1;
                }
            }
        }
        return location;
    }

    public void Sort()
    {
        items.Sort();
        items.Reverse();
        Print();
    }

    public void Print()
    {
        foreach (T item in items)
        {
            Debug.Log(item.ToString());
        }
        Debug.Log(items.Count);
    }

    #endregion
}
