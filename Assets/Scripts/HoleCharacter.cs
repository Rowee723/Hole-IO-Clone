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

    private int WorldSize = 0;

    private void Start()
    {
        WorldSize = LevelManager.Instance.GetSettings().Size * 5;
    }

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

        meshPos.x = Mathf.Clamp(meshPos.x, -WorldSize, WorldSize);
        meshPos.z = Mathf.Clamp(meshPos.z, -WorldSize, WorldSize);

        camPos.x = Mathf.Clamp(camPos.x, -WorldSize, WorldSize);
        camPos.z = Mathf.Clamp(camPos.z, -WorldSize - 3, WorldSize - 3);

        HoleMesh.transform.position = meshPos;
        MainCamera.transform.position = camPos;
    }
}
