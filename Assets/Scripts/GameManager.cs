using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> lives;
    public TextMeshProUGUI pointGUI;
    public Canvas pauseMenu;
    public int settingLive = 3;
    public int live = 3;
    public int point = 0;
    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        live = settingLive;
        point = 0;
    }

    public void DestroyHeart()
    {
        lives[live].SetActive(false);     
    }
    public void Pause()
    {
        if (isPause == false)
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
           
            UnPause();
        }
        
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        isPause = false;
        pauseMenu.gameObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        pointGUI.SetText(point.ToString());
        if (live <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
