using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
   public Transform target;        // The player object
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Default camera offset
    public float followSpeed = 5f;  // How fast the camera follows

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }
}
