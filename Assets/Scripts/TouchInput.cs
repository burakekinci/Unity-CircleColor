using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public Ray ray;
    public GameObject particle;
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
             ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
            {
                Instantiate(particle, transform.position, transform.rotation);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray);
    }
}