using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public Animator anim;
    public int hitsNumber = 0;
    public GameObject light;
    public bool isDancing;
    private int hitCount = 0;


	// Use this for initialization
	void Start ()
    {
        isDancing = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(this.hitCount == this.hitsNumber && isDancing == false)
        {
            StartDance();
            isDancing = true;
        }
	}

    void StartDance()
    {
        anim.SetBool("isDancing", true);
        this.light.SetActive(true);
        GameObject.Find("GameManager").SendMessage("SadSalaryHit");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SoundShot")
        {
            hitCount++;
        }
    }
}
