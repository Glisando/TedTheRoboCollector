using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : IComparable
{
    #region Fields

    GameObject gameObject;
    float distance;

    #endregion

    #region Constructors

    public Target(GameObject gameObject, Vector3 position)
    {
        this.gameObject = gameObject;
        UpdateDistance(position);
    }

    #endregion

    #region Properties

    public GameObject GameObject
    {
        get { return gameObject; }
    }
	
    public float Distance
    {
        get { return distance; }
    }
	
    #endregion

    #region Public methods

    public void UpdateDistance(Vector3 position)
    {
        distance = Vector3.Distance(gameObject.transform.position,
            position);
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Target tmp = obj as Target;

        if (tmp != null)
            return this.Distance.CompareTo(tmp.Distance);
        else
            throw new ArgumentException("Invalid argument type.");
    }
	
    public override string ToString()
    {
        return "[Target: Distance = " + distance + "]";
    }

    #endregion
}
