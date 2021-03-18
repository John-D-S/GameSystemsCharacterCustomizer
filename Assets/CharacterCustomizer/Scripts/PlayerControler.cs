using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private float cameraOffset = -10;
    [SerializeField]
    private GameObject cameraParent;

    private Rigidbody rb;
    private Vector3 cameraFacingDirection = - Vector3.forward;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 rotateVector = Vector3.zero;
        rotateVector.x = Input.GetAxis("Mouse Y");
        rotateVector.y = Input.GetAxis("Mouse X");

        cameraParent.transform.Rotate(rotateVector, Space.World);
    }
}
