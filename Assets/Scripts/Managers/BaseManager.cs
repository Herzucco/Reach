using UnityEngine;
using System.Collections;

public class BaseManager : MonoBehaviour {

	protected static readonly BaseManager instance = new BaseManager();
	
	public static BaseManager Instance
	{
		get { return instance; }
	}
}
