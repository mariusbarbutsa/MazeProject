using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float intensity = 0f;
    public bool shake = false;


    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ShakeOnCollision());
    }

    public IEnumerator ShakeOnCollision()
    {
        while (true)
        {
            if (shake == true)
            {
                float randX = Random.Range(-1f, 1f);
                float randY = Random.Range(-1f, 1f);
                float randZ = Random.Range(-1f, 1f);
                cameraTransform.localPosition = new Vector3(randX, randY, randZ).normalized * intensity;
                yield return null;
            }
            else
            {
                cameraTransform.localPosition = Vector3.zero;
                yield return null;
            }
        }
    }



}

