using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCharacter : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject HoleMesh;

    [Header("Hole Stats")]
    [SerializeField] float MovementSpeed = 1f;

    private void FixedUpdate()
    {
        if(LevelManager.Instance.IsGameRunning())
            MoveHole();
    }

    void MoveHole()
    {
        //Replace Input.GetAxis with joystick axes when porting to mobile
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
