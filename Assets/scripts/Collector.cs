using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
	#region Fields

    SortedList<Target> targets = new SortedList<Target>();
    Target targetPickup = null;

	float BaseImpulseForceMagnitude = 2.0f;
    const float ImpulseForceIncrement = 0.3f;
	
    Rigidbody2D rb2d;

	UnityAction<GameObject> pickupListener;

    #endregion

    #region Methods

    void Start()
    {
		Vector3 position = transform.position;
		position.x = 0;
		position.y = 0;
		position.z = 0;
		transform.position = position;

		rb2d = GetComponent<Rigidbody2D>();
		pickupListener += PickupHandler;
		EventManager.AddListener(pickupListener);
	}

    private void Update()
    {
        if (targetPickup == null && targets.Count > 0)
			SetTarget(targets[targets.Count - 1]);
	}

	void PickupHandler(GameObject pickup)
    {
		Target item = new Target(pickup, transform.position);

		Debug.Log("Target.Distance == " + item.Distance.ToString());

        targets.Add(item);
		UpdateTargets();
		SetTarget(targets[targets.Count - 1]);
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject == targetPickup.GameObject)
        {
            targets.Remove(targetPickup);

            Destroy(targetPickup.GameObject);

 
            if (targets.Count != 0)
            {
				UpdateTargets();
                SetTarget(targets[targets.Count - 1]);
				BaseImpulseForceMagnitude += ImpulseForceIncrement;
            }
		}
	}

	void SetTarget(Target pickup)
    {
		targetPickup = pickup;
		GoToTargetPickup();
	}

	void GoToTargetPickup()
    {
		Vector2 direction = new Vector2(
			targetPickup.GameObject.transform.position.x - transform.position.x,
			targetPickup.GameObject.transform.position.y - transform.position.y);
		direction.Normalize();
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce(direction * BaseImpulseForceMagnitude, 
			ForceMode2D.Impulse);
	}
	
    void UpdateTargets()
    {
		for (int i = 0; i < targets.Count; i++)
		{
			targets[i].UpdateDistance(transform.position);
		}

		targets.Sort();
	}
    #endregion
}
