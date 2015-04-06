using UnityEngine;
using System.Collections;

public class CircleCam : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 2, 0));
    }
}
