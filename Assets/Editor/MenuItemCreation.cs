using UnityEngine;
using UnityEditor;
using System.Collections;

public class MenuItemCreation : MonoBehaviour
{
    [MenuItem("Custom Objects/Mysteries/Slabs/Slabs")]
    private static void CreateSlabs()
    {
        Object o = Resources.Load("Prefabs/SlabPattern");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Mysteries/Slabs/Slabs Mandatory")]
    private static void CreateMandatorySlabs()
    {
        Object o = Resources.Load("Prefabs/SlabPatternMandotory");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Mysteries/Master Mind/MasterMind")]
    private static void CreateMasterMind()
    {
        Object o = Resources.Load("Prefabs/MasterMind/MasterMind");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Mysteries/Master Mind/Color")]
    private static void CreateColor()
    {
        Object o = Resources.Load("Prefabs/MasterMind/MasterMindColor");
        InstantiateObject(o);
    }

    private static void InstantiateObject(Object o)
    {
        GameObject g = Instantiate(o, Vector3.zero, Quaternion.identity) as GameObject;

        if (SelectParentObject() != null)
            g.transform.parent = SelectParentObject().transform;

        FocusObject(g);
    }

    private static void FocusObject(GameObject g)
    {
        GameObject[] gArray = new GameObject[1];
        gArray[0] = g;
        Selection.objects = gArray;
    }

    private static GameObject SelectParentObject()
    {
        return Selection.activeObject as GameObject;
    }
}