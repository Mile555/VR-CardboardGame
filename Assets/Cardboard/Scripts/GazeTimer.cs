using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeTimer : MonoBehaviour
{
    public Image dot;
    public UnityEvent GVRClick;
    bool gvrStatus;


    public float totalTime = 2;
    public float timer;

    // Update is called once per frame
    void Update()
    {

        if(gvrStatus){
            timer+=Time.deltaTime;
            dot.fillAmount=timer/totalTime;
        }
        if(timer>totalTime){
            GVRClick.Invoke();
        }
        //  RaycastHit hit;
        // if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        // {
        //     if (hit.transform == transform)
        //     {
        //         timer += Time.deltaTime;
        //         if (timer >= gazeTime)
        //         {
        //             // Trigger the interaction
        //         }
        //     }
        //     else
        //     {
        //         timer = 0;
        //     }
        // }
        // else
        // {
        //     timer = 0;
        // }
    }

    public void GvrOn(){
        gvrStatus=true;
    }
    public void GvrOff(){
        gvrStatus=false;
        timer=0;
        dot.fillAmount=0;
    }
}
