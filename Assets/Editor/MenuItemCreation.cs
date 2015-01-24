using UnityEngine;
using UnityEditor;
using System.Collections;

public class MenuItemCreation : MonoBehaviour
{
    [MenuItem("Custom Objects/Mysteries/Slabs")]
    private static void CreateSlabs()
    {
        Object o = Resources.Load("Prefabs/SlabPattern");
        InstantiateObject(o);
    }

    [MenuItem("Custom Objects/Mysteries/Slabs Mandatory")]
    private static void CreateMandatorySlabs()
    {
        Object o = Resources.Load("Prefabs/SlabPatternMandotory");
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