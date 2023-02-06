using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public LayerMask layerMask;
    public float movementSpeed;
    public float rotationSpeed;
    public float floatingDistance;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, floatingDistance, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        movementInput();
    }

    void raycastMovement()
    {
        Ray ray = new Ray(transform.position, -transform.up);

        Debug.DrawRay(ray.origin, ray.direction * floatingDistance, Color.red, 0.5f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, floatingDistance, layerMask))
        {
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            if(hit.normal.y.Equals(1)){
                transform.position = new Vector3(transform.position.x, floatingDistance, transform.position.z);
            }
        }
    }

    void movementInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            raycastMovement();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            raycastMovement();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}