using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    // declare our menu buttons.
    public Button play_button;
    public Button quit_button;

    // declare our game started bool.
    private bool game_started = false;

    // add event listeners to our buttons.
    void Start()
    {
        play_button.onClick.AddListener(start_game);
        quit_button.onClick.AddListener(quit_game);
    }

    // we want to start the game, load our scene.
    void start_game()
    {
        game_started = true;

        // load the game scene.
        SceneManager.LoadScene("SampleScene");
    }

    // we want to quit the game, exit.
    void quit_game()
    {
        // quit the application.
        Application.Quit();
    }
}
