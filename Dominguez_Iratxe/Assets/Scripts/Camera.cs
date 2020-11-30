using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject esfera;
    private Vector3 desplazamiento;
    // Start is called before the first frame update
    void Start()
    {
        desplazamiento = transform.position - esfera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = esfera.transform.position + desplazamiento;

    }
}