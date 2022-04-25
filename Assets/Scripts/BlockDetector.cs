using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BlockStats stats = collision.gameObject.GetComponent<BlockStats>();

        if (stats != null)
        {
            LevelManager.Instance.AddPoints(stats.GetPoints());
            Destroy(collision.gameObject);
        }
    }
}
