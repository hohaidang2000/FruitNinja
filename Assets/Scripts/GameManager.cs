using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int settingLive = 3;
    public int live = 3;
    public int point = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        live = settingLive;
        point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(live <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
