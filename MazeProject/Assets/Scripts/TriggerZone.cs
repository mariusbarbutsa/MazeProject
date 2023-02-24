using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public TriggerBehaviour myBehaviour;

    public GameObject affectedGameObject;

    private bool playerInside = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInside == true)
        {
            Vector3 tempPos = affectedGameObject.transform.position;

            if (myBehaviour == TriggerBehaviour.Disappear)
            {
                tempPos.y = 1.9f;
            }
            if (myBehaviour == TriggerBehaviour.Appear)
            {
                tempPos.y = 1.2494f;
            }

            affectedGameObject.transform.position = tempPos;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Vector3 tempPos = affectedGameObject.transform.position;

        if (other.tag.Equals("Player"))
        {
            playerInside = false;

            if (myBehaviour == TriggerBehaviour.Disappear)
            {
                tempPos.y = 1.2494f;
            }
            if (myBehaviour == TriggerBehaviour.Appear)
            {
                tempPos.y = 1.9f;
            }

        }
        affectedGameObject.transform.position = tempPos;

    }

    public enum TriggerBehaviour
    {
        Appear,
        Disappear
    }

}
