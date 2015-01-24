using UnityEngine;
using System.Collections;

public abstract class Collision : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            PlayerEnter(other.gameObject);
    }

    protected abstract void PlayerEnter(GameObject player);
}
