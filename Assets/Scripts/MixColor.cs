using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MixColor : MonoBehaviour {

	[SerializeField]
	private AmbiantColors myColor;
	private ColorConfigurator config;
	private PlanetsMixer mixer;
	private Renderer mRenderer;
	private Color baseColor;
	private Color currentColor;

	void Awake(){
		config = Resources.Load ("ColorConfig") as ColorConfigurator;
		mRenderer = renderer;
		baseColor = myColor == AmbiantColors.DARKCOLOR ? config.lightColor : config.darkColor;

	}

	void Start(){
		mixer = FindObjectOfType<PlanetsMixer> ();
	}

	void Update(){
		Color targetColor = Color.Lerp (Color.white, baseColor, ((float)mixer.CurrentState + 2) / (float)mixer.StateNumbers);
		renderer.material.color = Color.Lerp (renderer.material.color, targetColor, 0.1f);
		currentColor = targetColor; 
	}

}
