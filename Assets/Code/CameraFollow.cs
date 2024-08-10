using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject followCharacter;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = followCharacter.transform.position + new Vector3(0,0,-5);
    }
}
