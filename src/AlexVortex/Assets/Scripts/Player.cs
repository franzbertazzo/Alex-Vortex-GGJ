using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckFall();
        if (Input.GetKeyDown("r"))
        {
            GameObject.Find("GameManager").SendMessage("Restart");
        }
    }


    private void OnTriggerStay(Collider trigger)
    {
        if(trigger.gameObject.tag == "Dancer")
        {
            Debug.Log("dentro");
        }
    }

    public void CheckFall()
    {
        if (this.transform.position.y < -10)
        {
            Debug.Log("Caiu");
            GameObject.Find("GameManager").SendMessage("GameOver");
        }
    }
}
