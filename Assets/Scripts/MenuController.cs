using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private Button _play;
    
    void Start()
    {
        _play = GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Button>();
        _play.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
