using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUpTransform : MonoBehaviour
{
    void Start()
    {
        //round position
        Vector3 vector3 = transform.position;
        vector3.x = Mathf.Round(vector3.x);
        vector3.y = Mathf.Round(vector3.y);
        vector3.z = Mathf.Round(vector3.z);
        transform.position = vector3;
        //round size
        Vector3 vector3Size = transform.localScale;
        vector3Size.x = Mathf.Round(vector3Size.x);
        vector3Size.y = Mathf.Round(vector3Size.y);
        vector3Size.z = Mathf.Round(vector3Size.z);
    }

}
