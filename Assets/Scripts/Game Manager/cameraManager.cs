using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        Vector3 lookPosition = new Vector3(offset.x + target.position.x, offset.y + target.position.y, offset.z + target.position.z);
        transform.position = lookPosition;
    }
}
