using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGameManager : MonoBehaviour
{

    public float distancia;
    public int level;
    public int totalSadSalarymen = 1;
    public float levelDuration = 0;
    public TextMesh counter;

    public GameObject restartScreen;
   
    

    private float timer = 0;

    // Use this for initialization
	void Awake ()
    {
        timer = levelDuration;
        float decTax = (distancia*Time.deltaTime) / this.levelDuration;
        GameObject.Find("SoundGun").SendMessage("SetDecTax", decTax);
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter.text = totalSadSalarymen.ToString();
        this.timer -= Time.deltaTime;

        if (this.totalSadSalarymen == 0)
        {
            Debug.Log("End of level.");
            LevelComplete();
        }

        if(timer < 0)
        {
            GameObject.Find("SoundGun").SendMessage("SetDecTax", 0f);
            GameOver();
        }
    }

    public void SadSalaryHit()
    {
        
        this.totalSadSalarymen--;
    }


    public float GetDuration()
    {
        return this.levelDuration;
    }


    public void GameOver()
    {
        Debug.Log("Restart");
        restartScreen.SetActive(true);
    }

    public void LevelComplete()
    {
        SceneManager.LoadScene("Level" + (level + 1).ToString());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
