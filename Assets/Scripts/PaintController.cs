using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintController : MonoBehaviour
{
    public LayerMask layerMask;
    private float paintRange = 10;
    private Color[] colors = new Color[4];

    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.yellow;
        colors[1] = Color.red;
        colors[2] = Color.cyan;
        colors[3] = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            Debug.DrawRay(ray.origin, ray.direction * paintRange, Color.blue, 0.5f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, paintRange, layerMask))
            {
                if(hit.transform.tag == "Unpaintable")
                {
                    Debug.Log("Cube is unpaintable!");
                } else
                {
                    Debug.Log("Painted the cube!");
                    hit.collider.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                }
            }
        }
    }
}
