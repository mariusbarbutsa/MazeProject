using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float rotationSpeed = 80f;
    public float moveSpeed = 2f;
    public float jumpSpeed = 2f;
    public GameObject endScreen;
    public GameObject Timer;
    private Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {

        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = transform.position;
        Vector3 tempRot = transform.eulerAngles;
        Vector3 tempVel = myRigidBody.velocity;

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            tempPos += transform.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            tempPos -= transform.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tempVel.y = jumpSpeed;
        }

        //Rotation
        if (Input.GetKey(KeyCode.A))
        {
            tempRot.y -= rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            tempRot.y += rotationSpeed * Time.deltaTime;
        }


        transform.eulerAngles = tempRot;
        transform.position = tempPos;
        myRigidBody.velocity = tempVel;

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag.Equals("Respawn"))
        {

            endScreen.SetActive(true);
            Timer.SetActive(false);

        }

        if (coll.gameObject.tag.Equals("Finish"))
        {

            endScreen.SetActive(true);
            Timer.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        endScreen.SetActive(false);

    }
}
