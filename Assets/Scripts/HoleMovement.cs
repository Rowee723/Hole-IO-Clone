using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] float Speed = 1f;

    private void FixedUpdate()
    {
        float x  = Input.GetAxis("Horizontal") * Speed * Time.fixedDeltaTime;
        float z  = Input.GetAxis("Vertical") * Speed * Time.fixedDeltaTime;

        Vector3 pos = gameObject.transform.position;

        pos.x += x;
        pos.z += z;

        gameObject.transform.position = pos;
    }
}
