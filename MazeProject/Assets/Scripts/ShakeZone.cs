using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeZone : MonoBehaviour
{
    public CameraShake cameraShake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            cameraShake.shake = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            cameraShake.shake = false;
        }
    }

}
