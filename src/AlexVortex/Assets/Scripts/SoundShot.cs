using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundShot : MonoBehaviour
{
    public float speed = 0;
    public float lifeTime = 0;
    public LineRenderer lineRender;
    [SerializeField] private GameObject light;
    //[SerializeField] private GameObject boop;

    private float time = 0;

    private Vector3 direction = new Vector3(0, 0, 0);



    public float ThetaScale = 0.01f;
    public float radius = 3f;
    private int Size;
    private float Theta = 0f;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(this.time >= this.lifeTime)
        {
            Object.Destroy(this.gameObject);
        }
        else
        {
            this.time += Time.deltaTime;
        }

        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 1f);
        lineRender.SetVertexCount(Size);

        for (int i = 0; i < Size; i++)
        {
            Theta += (2.0f * Mathf.PI * ThetaScale);
            float x = radius * Mathf.Cos(Theta);
            float y = radius * Mathf.Sin(Theta);
            lineRender.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Surface")
        {
            Debug.Log("HitSurface");
            light.gameObject.SetActive(true);
            this.lineRender.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Dancer")
        {
            Debug.Log("HitDancer");
            light.gameObject.SetActive(true);
            this.lineRender.gameObject.SetActive(false);
        }
    }
}
