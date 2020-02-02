using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Realiza os disparos.
/// </summary>
public class SoundGun : MonoBehaviour
{
    public float coolingTime = 0.1f;
    public GameObject shot;
    public Transform shotSpawPoint;
    public GameObject energyBar;
    public AudioSource music;
    public float spectrumSense = 30;
    public Vector2Int spectrumRange = new Vector2Int(0, 0);

    private float cooling = 0;
    private bool isCooling = false;
    private float decTax = 0;


	// Use this for initialization
	void Start ()
    {
        this.cooling = this.coolingTime;
    }
	

	// Update is called once per frame
	void Update ()
    {
        if(this.cooling < this.coolingTime)
        {
            this.isCooling = true;
            this.cooling += Time.deltaTime;
        }
        else
        {
            this.isCooling = false;
        }

        //if (Input.GetMouseButtonDown(0) && !this.isCooling)
        //{
        //    FireShot();
        //}
        // Mathf.Clamp(spectrum[i] * (50 + i * i), 0, 50);

        //UpdateEnergyBar();
        float[] spectrum = new float[64];
        this.music.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        

        for (int i = this.spectrumRange.x; i < this.spectrumRange.y; i++)
        {
            //Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i,0, 0), new Vector3(i, Mathf.Clamp(spectrum[i] * (50 + i * i), 0, 50)), Color.cyan);
            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            //Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);

            if (Mathf.Clamp(spectrum[i] * (50 + i * i), 0, 50) > spectrumSense && !this.isCooling)
            {
                FireShot();
            }
        }
    }


    private void FireShot()
    {
        GameObject shot = Instantiate(this.shot, this.shotSpawPoint.position, this.shotSpawPoint.rotation);
        shot.GetComponent<Rigidbody>().velocity = shot.transform.forward * shot.GetComponent<SoundShot>().speed;
        this.cooling = 0;
    }


    public void SetDecTax(float tax)
    {
        this.decTax = tax;
    }


    private void UpdateEnergyBar()
    {
        this.energyBar.transform.Translate(0, 0, -this.decTax);
    }
}
