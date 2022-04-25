using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCharacter : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;

    [Header("Hole Stats")]
    [SerializeField] GameObject HoleMesh;
    [SerializeField] float MovementSpeed = 1f;

    private void FixedUpdate()
    {
        MoveHole();
    }

    void MoveHole()
    {
        float x = Input.GetAxis("Horizontal") * MovementSpeed * Time.fixedDeltaTime;
        float z = Input.GetAxis("Vertical") * MovementSpeed * Time.fixedDeltaTime;

        Vector3 meshPos = HoleMesh.transform.position;
        Vector3 camPos = MainCamera.transform.position;

        meshPos.x += x;
        meshPos.z += z;
        
        camPos.x += x;
        camPos.z += z;

        HoleMesh.transform.position = meshPos;
        MainCamera.transform.position = camPos;
    }
}
