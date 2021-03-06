﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using System.IO;


public class ColorConfiguratorCreator{
	#if UNITY_EDITOR
	[MenuItem("Assets/Create/YourClass")]
	#endif
	public static void CreateAsset ()
	{
		ColorConfigurator.CreateAsset<ColorConfigurator> ();
	}
}

public enum AmbiantColors{
	DARKCOLOR,
	LIGHTCOLOR
}

public class ColorConfigurator : ScriptableObject
{

	public Color darkColor;
	public Color lightColor;

	public static void CreateAsset<T> () where T : ScriptableObject
	{
		#if UNITY_EDITOR
		T asset = ScriptableObject.CreateInstance<T> ();
		
		string path =  AssetDatabase.GetAssetPath (Selection.activeObject);
		if (path == "") 
		{
			path = "Assets/Datas";
		} 
		else if (Path.GetExtension (path) != "") 
		{
			path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
		}
		
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/New " + typeof(T).ToString() + ".asset");
		
		AssetDatabase.CreateAsset (asset, assetPathAndName);
		
		AssetDatabase.SaveAssets ();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
		#endif

	}
}
