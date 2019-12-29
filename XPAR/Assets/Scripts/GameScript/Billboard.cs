using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform camTransform;
    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = camTransform.rotation * originalRotation;
    }
}
