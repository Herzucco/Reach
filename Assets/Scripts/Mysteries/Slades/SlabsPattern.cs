using UnityEngine;
using System.Collections;

public class SlabsPattern : Mystery {

    [Range(1, 8)]
    [Header("The number of mandatory slades for the pattern to validate")]
    public int slabNumber;

   private GameObject[] _slabs = new GameObject[4];
   private SlabCollision[] _mysteriesSlab = new SlabCollision[4];
   private int _slabNumber;

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
            if (_mysteriesSlab[i].isActivated)
            {
                if (_mysteriesSlab[i].isMandatory)
                    _slabNumber++;
                
                else
                    _slabNumber--;
            }
        }

        if (_slabNumber == slabNumber)
        {
            Debug.Log("toto");
            Resolve();
        }

        _slabNumber = 0;
    }

}
