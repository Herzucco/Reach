using UnityEngine;
using System.Collections;

public class MasterMind : Mystery {

    [Header("Drag'n'drop 4 master minds color in it")]
    public GameObject[] _masterMindColor;

    [Header("Drag'n'drop 4 master minds CONTROLLER color in it")]
    public GameObject[] _masterMindControlColor;

    private EnumColor[] _enumColor = new EnumColor[4];

    [Header("! DONT TOUCH ! FOR DEBUG PURPOSE TO SEE THE RANDOM COLOR")]
    public EnumColor[] publicColor;
    private int colorToReach;

    private int tempColorToReach = 0;

    private MasterMindChangeColor[] _masterMindChangeColor;

	void Start () {
        _masterMindChangeColor = new MasterMindChangeColor[_masterMindColor.Length];

	    for(int i = 0; i < _masterMindColor.Length; i++)
        {
            _masterMindChangeColor[i] = _masterMindColor[i].GetComponent<MasterMindChangeColor>();
        }

        for (int i = 0; i < _enumColor.Length; i++)
        {
            _enumColor[i] = (EnumColor)Random.Range(0, 3);
        }

        publicColor = _enumColor;
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < _masterMindChangeColor.Length; i++)
        {
			PhotonView phView = _masterMindControlColor[i].GetComponent<PhotonView>();
			if (_masterMindChangeColor[i].colorEnum == _enumColor[i])
            {

				if(_masterMindControlColor[i].GetComponent<MasterAnswers>().rpced){
					_masterMindControlColor[i].renderer.material.color = Color.green;
				}

				phView.RPC("AlertResolve", PhotonTargets.Others);
                colorToReach++;
            }
            else
            {
				if(_masterMindControlColor[i].GetComponent<MasterAnswers>().rpced){
					_masterMindControlColor[i].renderer.material.color = Color.white;
				}
				phView.RPC("AlertBad", PhotonTargets.Others);
            }
        }

        tempColorToReach = colorToReach;

        if(colorToReach == 4)
        {
            Resolve();
        }

        colorToReach = 0;
	}
}
