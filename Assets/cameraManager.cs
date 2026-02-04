using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target);
        Vector3 lookPosition = new Vector3(offset.x + target.position.x, offset.y + target.position.y, offset.z + target.position.z);
        transform.position = lookPosition;
    }
}
