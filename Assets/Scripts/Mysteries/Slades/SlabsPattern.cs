using UnityEngine;
using System.Collections;

public class SlabsPattern : MonoBehaviour {

   private GameObject[] _slabs = new GameObject[4];
   private SlabCollision[] _mysteriesSlab = new SlabCollision[4];

    private void Start()
    {
        _slabs = GameObject.FindGameObjectsWithTag("Slabs");
        
        for(int i = 0; i < _slabs.Length; i++)
        {
            if( _slabs[i].GetComponent<SlabCollision>() != null)
                _mysteriesSlab[i] = _slabs[i].GetComponent<SlabCollision>();
        }
    }

    private void Update()
    {
        for (int i = 0; i < _slabs.Length; i++)
        {
            if (_mysteriesSlab[i].isMandatory && _mysteriesSlab[i].isActivated)
                Debug.Log("Activated");
            else
                Debug.Log("NotActivated");
        }
    }

}
