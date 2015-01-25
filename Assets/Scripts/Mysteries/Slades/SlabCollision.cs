using UnityEngine;
using System.Collections;

public class SlabCollision : Collision {

    public bool isMandatory;
    public Color color = Color.white;
    private bool _isActivated = false;

    public bool isActivated
    {
        get { return _isActivated; }
    }

    private void Start()
    {
        renderer.material.color = color;
    }
    protected override void PlayerEnter(GameObject player)
    {
		GameObject go = GameObject.FindGameObjectWithTag ("InteractSound");
		if (go != null) {
			go.GetComponent<AudioSource> ().Play ();
		}
        if (_isActivated)
        {
            renderer.material.color = Color.white;
            _isActivated = false;
        }
        else
        {
            renderer.material.color = Color.green;
            _isActivated = true;
        }
    }
}
