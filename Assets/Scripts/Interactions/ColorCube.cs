using UnityEngine;
using System.Collections;

public class ColorCube : ContextAction {

	public Renderer renderer;

	public override void Action ()
	{
		renderer.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
	}
}
