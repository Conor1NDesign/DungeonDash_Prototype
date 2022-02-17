using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen_Tile : MonoBehaviour
{
    public List<GameObject> connectionPoints;

    public GameObject antiOverlapTrigger;

    public GameObject exitObject;


    public void Awake()
    {
        if (gameObject.tag == "StandardTile")
        {
            if (antiOverlapTrigger == null)
            {
                Debug.LogError("The tile named '" + gameObject + "' is missing an anti-overlap trigger, please add one to the prefab before attempting to generate a map.");
            }

            if (exitObject.activeSelf)
            {
                Debug.LogWarning("The Exit Object on " + gameObject + " is active in it's prefab. Please set it to inactive!");
                exitObject.SetActive(false);
            }
        }
    }

    public void GenerateExit()
    {
        if (exitObject != null)
        {
            exitObject.SetActive(true);
        }
        else
        {
            Debug.LogError("The prefab for tile " + gameObject + " does not have an Exit attached to it!");
        }
    }
}
