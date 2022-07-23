using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggleButton : MonoBehaviour
{


    public GameObject toggleObject;
    public Material onMaterial;
    public Material offMaterial;

    // Start is called before the first frame update
    void Start()
    {
        ApplyMaterial();
    }

    void OnTriggerEnter(Collider other)
    {
        toggleObject.SetActive(!toggleObject.activeSelf);
        ApplyMaterial();
    }

    private void ApplyMaterial()
    {
        GetComponent<Renderer>().material = toggleObject.activeSelf ? onMaterial : offMaterial;
    }
}
