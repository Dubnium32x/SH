using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Vector3 RotationDirection;
    void Update()
    {
        transform.Rotate(RotationDirection.x, RotationDirection.y, RotationDirection.z, Space.Self);
    }
}
