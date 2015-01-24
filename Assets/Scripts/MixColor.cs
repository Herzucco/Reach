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

	void Awake(){
		config = Resources.Load ("ColorConfig") as ColorConfigurator;
		middleColor = new Color ((config.darkColor.r + config.lightColor.r) / 2,
		                        (config.darkColor.g + config.lightColor.g) / 2,
		                        (config.darkColor.b + config.lightColor.b));
		mRenderer = renderer;
		baseColor = myColor == AmbiantColors.DARKCOLOR ? config.darkColor : config.lightColor;

	}

	void Start(){
		mixer = FindObjectOfType<PlanetsMixer> ();
	}

	void Update(){
		Color targetColor = Color.Lerp (baseColor, middleColor, mixer.CurrentState / mixer.StateNumbers);
		renderer.material.color = Color.Lerp (renderer.material.color, targetColor, 0.1f);
	}

}
