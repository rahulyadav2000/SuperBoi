using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLeft : MonoBehaviour
{
    public Text text;
    public static float timeleft = 15f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("TimeUp", 2f);

        timeleft -= Time.deltaTime;

        if(timeleft < 0)
            timeleft = 0;
            text.text = "Time Left : " + Mathf.Round(timeleft);
                  
    }

    void TimeUp()
    {
        if (timeleft == 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
