using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCorrection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}
