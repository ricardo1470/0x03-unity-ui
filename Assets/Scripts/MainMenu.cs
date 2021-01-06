using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // button play
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayMaze);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // load maze scene
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }
}
