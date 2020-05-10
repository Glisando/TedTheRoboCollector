using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PickupsTextUI : MonoBehaviour {

	[SerializeField] Text text;

	UnityAction<GameObject> pickupListener;
	int pickupsSpawned = 0;
	string textTemplate = "Pickups spawned: ";

	void Start() {
		pickupListener += PickupSpawnHandler;
		EventManager.AddListener(pickupListener);
		text.text = textTemplate + pickupsSpawned + "/50";
	}


    void PickupSpawnHandler(GameObject pickup)
    {
		pickupsSpawned++;
		text.text = textTemplate + pickupsSpawned + "/50";
	}
}
