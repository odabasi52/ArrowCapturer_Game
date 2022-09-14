using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] KeyCode key;
    void Update()
    {
        if (Input.GetKey(key))
        {
            this.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.blue;
            this.GetComponentsInChildren<MeshRenderer>()[1].material.color = Color.blue;
        }

        else
        {
            this.GetComponentsInChildren<MeshRenderer>()[0].material.color = Color.cyan;
            this.GetComponentsInChildren<MeshRenderer>()[1].material.color = Color.cyan;
        }
    }

}
