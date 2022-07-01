using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    [SerializeField] GameObject[] sun;
    [SerializeField] float speedOfTurnAroundSun;
    [SerializeField] float speedOfTurnAroundItself;
    [SerializeField] float count=0;

    void Awake() 
    {
        sun = GameObject.FindGameObjectsWithTag("Sun");

        if(this.gameObject.tag=="World")
        {
            speedOfTurnAroundSun=20f;
            speedOfTurnAroundItself=100f;
        }
        else if(this.gameObject.tag=="Saturn")
        {
            speedOfTurnAroundSun=10f;
            speedOfTurnAroundItself=80f;
        }
        else if(this.gameObject.tag=="Mars")
        {
            speedOfTurnAroundSun=30f;
            speedOfTurnAroundItself=150f;
        }

    }

    void FixedUpdate() 
    {
        // Turn around Sun
        transform.RotateAround(sun[0].transform.position,Vector3.up,speedOfTurnAroundSun*Time.deltaTime);
        // Turn around Itself
        transform.RotateAround(this.transform.position,Vector3.up,speedOfTurnAroundItself*Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="Line")
        {
            count+=1;  
            if(count>1)
            {
                Debug.Log(this.gameObject.name+" turned around the Sun about = "+(count-1));
            }
        }
    }
}
