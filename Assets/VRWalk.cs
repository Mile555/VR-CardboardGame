using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRWalk : MonoBehaviour
{
    public Transform vrCamera;

    public float toggleAngleF = 20.0f;
    public float toggleAngleB = -10.0f;

    // movement speed
    public float speedF = 15.0f;
    public float speedB = 5.0f;

    //Should I move forward/bacwards or not
    public bool moveForward;
    public bool moveBackward;

    //CharacterController script
    public CharacterController cc;

    public int numOfCoins = 0;

    public AudioSource audioSrc;
    public AudioClip coinCollectionSound;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Find the CharacterController
        cc = GetComponentInParent<CharacterController>();

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vrCamera.eulerAngles.x >= toggleAngleF && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
            moveBackward = false;
        }
        else if (vrCamera.eulerAngles.x <= toggleAngleB && vrCamera.eulerAngles.x > -50.0f)
        {
            moveBackward = true;
            moveForward = false;
        }
        else
        {
            moveForward = false;
            moveBackward = false;
        }

        if (moveForward)
        {
            //Find the forward direction
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            //Tell CharacterController to move forward
            cc.SimpleMove(forward * speedF);
        }
        else if (moveBackward)
        {
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            //m_Rigidbody.velocity = -transform.forward * m_Speed;
            Vector3 forward = vrCamera.TransformDirection(-Vector3.forward);
            cc.SimpleMove(forward * speedB);

           

        }





        // public Transform vrCamera;

        // public float speed=3.0f;

        // public float toggleAngle=30.0f;
        
        // public bool move;

        // private CharacterController cc;


        // // Start is called before the first frame update
        // void Start()
        // {
        //     vrCamera=Camera.main.transform;

        // }

        // // Update is called once per frame
        // void Update()
        // {
            
        //     float verticalRotation = vrCamera.rotation.eulerAngles.x;
            
        //     if (verticalRotation > toggleAngle && verticalRotation < 90.0f)
        //     {
        //         move=true;
        //     }
        //     else
        //     {
        //         move=false;
        //     }
        //     if(move){
        //         transform.position += transform.forward * speed * Time.deltaTime;
                
            
                
        //     }
        // }
    }
}
