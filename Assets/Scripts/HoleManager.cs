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
    [SerializeField] float HoleSize = 1f;

    Mesh Ground3DMesh;

    private void FixedUpdate()
    {
        //If hole moved
        if(HoleMesh.transform.hasChanged == true)
        {
            HoleMesh.transform.hasChanged = false;
            Vector3 Position = HoleMesh.transform.position;
            Vector3 Scale = HoleMesh.transform.localScale;

            //Translation 3D position to 2D position and also copy scale
            Hole2DCollider.transform.position = new Vector2(Position.x, Position.z);
            Hole2DCollider.transform.localScale = new Vector3(Scale.x, Scale.z, 1f) * HoleSize;

            CreateHole();
            CreateMesh();
        }
    }

    private void CreateHole()
    {
        Vector2[] PosArrays = Hole2DCollider.GetPath(0);

        //Store the points of the hole
        for (int i = 0; i < PosArrays.Length; i++)
        {
            PosArrays[i] = Hole2DCollider.transform.TransformPoint(PosArrays[i]);
        }

        Ground2DCollider.pathCount = 2;
        Ground2DCollider.SetPath(1, PosArrays);

        
    }

    private void CreateMesh()
    {
        if (Ground3DMesh != null)
            Destroy(Ground3DMesh);

        Ground3DMesh = Ground2DCollider.CreateMesh(true, true);
        Ground3DCollider.sharedMesh = Ground3DMesh;
    }

    public IEnumerator LevelUpHole()
    {
        Vector3 InitialScale = HoleMesh.transform.localScale;
        Vector3 EndScale = InitialScale * 2;
        float time = 0.0f;

        //Scale the hole gradually using lerp
        while(time <= 0.5f)
        {
            time += Time.deltaTime;
            HoleMesh.transform.localScale = Vector3.Lerp(InitialScale, EndScale, time);
        }

        yield return null;
    }
}
