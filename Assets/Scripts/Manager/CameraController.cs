using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform verRotationPoint;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float limitRotationVertical;

    private float horRotation;
    private float verRotation = 15f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        transform.position = target.position;

        Rotate();
    }

    private void Rotate()
    {
        horRotation += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        verRotation += Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

        verRotation = Mathf.Clamp(verRotation, 0f, limitRotationVertical);

        transform.rotation = Quaternion.Euler(0f, horRotation, 0f);
        verRotationPoint.localRotation = Quaternion.Euler(verRotation, 0f, 0f);
    }
}
