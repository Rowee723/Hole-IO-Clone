using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [Header("Ground")]
    [SerializeField] GameObject GroundMesh;
    [SerializeField] PolygonCollider2D Ground2DCollider;
    [SerializeField] MeshCollider Ground3DCollider;

    [Header("Hole")]
    [SerializeField] GameObject HoleMesh;
    [SerializeField] PolygonCollider2D Hole2DCollider;
    [SerializeField] float HoleSize = 0.5f;

    Mesh Ground3DMesh;

    private void FixedUpdate()
    {
        if(HoleMesh.transform.hasChanged == true)
        {
            Vector3 Position = HoleMesh.transform.position;

            Hole2DCollider.transform.position = new Vector2(Position.x, Position.z);
            Hole2DCollider.transform.localScale = HoleMesh.transform.localScale * HoleSize;

            Vector2[] PosArrays = Hole2DCollider.GetPath(0);

            for(int i = 0; i < PosArrays.Length; i++)
            {
                PosArrays[i] = Hole2DCollider.transform.TransformPoint(PosArrays[i]);
            }

            Ground2DCollider.pathCount = 2;
            Ground2DCollider.SetPath(1, PosArrays);

            if (Ground3DMesh != null)
                Destroy(Ground3DMesh);

            Ground3DMesh = Ground2DCollider.CreateMesh(true, true);
            Ground3DCollider.sharedMesh = Ground3DMesh;
            

            HoleMesh.transform.hasChanged = false;
        }
    }

    public void LevelUpHole()
    {
        Vector3 HoleScale = HoleMesh.transform.localScale;

        HoleScale.x += 0.5f;
        HoleScale.z += 0.5f;

        HoleMesh.transform.localScale = HoleScale;
    }
}
