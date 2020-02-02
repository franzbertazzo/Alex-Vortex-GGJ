using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingLight : MonoBehaviour
{

    public float pulseSpeed = 0;
    public float maxIntensity = 0;
    public float minIntensity = 0;
    public bool pulse = false;

    public float maxRange = 0;
    public float minRange = 0;

    public Light light;

    private bool fadeIn = false;
    private bool fadeOut = false;

    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (this.pulse) Pulse();
        else if (this.fadeIn) FadeIn();
        else if (this.fadeOut) FadeOut();
	}

    private void Pulse()
    {
        if (this.fadeIn)
        {
            FadeIn();
        }
        else if(this.fadeOut)
        {
            FadeOut();
        }
        else if(this.light.intensity == this.minIntensity)
        {
            FadeIn();
        }
        else if(this.light.intensity == this.maxIntensity)
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        this.fadeIn = true;
       // IncreaseRange();
        IncreaseIntensity();
    }

    public void FadeOut()
    {
        this.fadeOut = true;
       // DecreaseRange();
        DecreaseIntensity();
    }

    public void IncreaseIntensity()
    {
        if (this.light.intensity < this.maxIntensity)
        {
            this.light.intensity += this.pulseSpeed * Time.deltaTime;
        }
        else
        {
            this.light.intensity = this.maxIntensity;
            this.fadeIn = false;
        }
    }

    public void DecreaseIntensity()
    {
        if (this.light.intensity > this.minIntensity)
        {
            this.light.intensity -= this.pulseSpeed * Time.deltaTime;
        }
        else
        {
            this.light.intensity = this.minIntensity;
            this.fadeOut = false;
        }
    }

    public void IncreaseRange()
    {
        if (this.light.range < this.maxRange)
        {
            this.light.range += this.pulseSpeed * Time.deltaTime;
        }
        else
        {
            this.light.range = this.maxRange;
            this.fadeIn = false;
        }
    }

    public void DecreaseRange()
    {
        if (this.light.range > this.minRange)
        {
            this.light.range -= this.pulseSpeed * Time.deltaTime;
        }
        else
        {
            this.light.range = this.minRange;
            this.fadeOut = false;
        }
    }
}
