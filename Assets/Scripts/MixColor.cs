using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MixColor : MonoBehaviour {

	[SerializeField]
	private AmbiantColors myColor;
	private ColorConfigurator config;
	private PlanetsMixer mixer;
	private Color middleColor;
	private Renderer mRenderer;
	private Color baseColor;
	private Color currentColor;

	void Awake(){
		config = Resources.Load ("ColorConfig") as ColorConfigurator;
		middleColor = myColor == AmbiantColors.DARKCOLOR ? config.lightColor : config.darkColor;
		mRenderer = renderer;
		baseColor = myColor == AmbiantColors.DARKCOLOR ? config.darkColor : config.lightColor;

	}

	void Start(){
		mixer = FindObjectOfType<PlanetsMixer> ();
	}

	void Update(){
		Debug.Log ((float)mixer.CurrentState / (float)mixer.StateNumbers);
		Color targetColor = Color.Lerp (baseColor, middleColor, (float)mixer.CurrentState / (float)mixer.StateNumbers);
		renderer.material.color = Color.Lerp (renderer.material.color, targetColor, 0.1f);
		currentColor = targetColor; 
	}

}
