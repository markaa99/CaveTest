using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Toggles all objects with the given tag when enabling / disabling the parent object.
/// </summary>
public class TagToggle : MonoBehaviour
{
    public string toggleTagName;

    private GameObject[] _disabledCache = new GameObject[0];

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
        if (active)
        {
            foreach (var obj in _disabledCache)
            {
                obj.SetActive(true);
            }
            _disabledCache = new GameObject[0];
        }
        else
        {
            var objects = GameObject.FindGameObjectsWithTag(toggleTagName);
            foreach (var obj in objects)
            {
                obj.SetActive(false);
            }
            _disabledCache = objects;
        }
    }
}
