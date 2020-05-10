using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Fields

    static List<PickupSpawner> invokers = new List<PickupSpawner> ();
    static List<UnityAction<GameObject>> listeners = new List<UnityAction<GameObject>> ();

    #endregion

    #region Public methods

    public static void AddInvoker(PickupSpawner invoker)
    {
   
        invokers.Add(invoker);
        foreach (UnityAction<GameObject> listener in listeners)
        {
            invoker.AddListener(listener);
        }
    }

    public static void AddListener(UnityAction<GameObject> handler)
    {       
   
        listeners.Add(handler);
        foreach (PickupSpawner invoker in invokers)
        {
            invoker.AddListener(handler);
        }
    }

    #endregion
}
