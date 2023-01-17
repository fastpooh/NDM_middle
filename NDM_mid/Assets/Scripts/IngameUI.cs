using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IngameUI : MonoBehaviour
{
    public GameObject gameEndUI;
    public TextMeshProUGUI winText;
    public MonsterCtrl monster;
    void Start()
    {
        gameEndUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(monster.losePlayer == 1)
        {
            winText.text = "You Lose!";
            gameEndUI.SetActive(true);
        }
        else if(monster.losePlayer == 2)
        {
            winText.text = "You Win!";
            gameEndUI.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("StartUI");
    }
}
