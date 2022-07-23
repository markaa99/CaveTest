using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Toggles all objects with the given tag when enabling / disabling the parent object.
/// </summary>
public class TagToggle : MonoBehaviour
{

    public string toggleTagName;

    private void OnEnable()
    {
        SetTaggedActive(true);
    }

    private void OnDisable()
    {
        SetTaggedActive(false);
    }

    private void SetTaggedActive(bool active)
    {
        var objects = GameObject.FindGameObjectsWithTag(toggleTagName);
        foreach (var obj in objects)
        {
            obj.GetComponent<CubeSpawner>().gameObject.SetActive(active);
        }
    }
}
