using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour
{

    // var to see if the game is paused.
    public static bool game_is_paused = false;

    // used to enabled/disable the ui.
    public GameObject pause_menu_ui;

    // continue button.
    public Button continue_button;
    public Button quit_button;

    // Start is called before the first frame update
    void Start()
    {
       continue_button.onClick.AddListener(resume);
       quit_button.onClick.AddListener(quit_game);
    }

    void quit_game() {

        // quit the application.
        Application.Quit();
    }

    void pause() {

        // display pause menu.
        pause_menu_ui.SetActive(true);

        // pause the game.
        Time.timeScale = 0f;

        // set the game to paused.
        game_is_paused = true;
    }

    void resume() {

        // hide pause menu.
        pause_menu_ui.SetActive(false);

        // resume the game.
        Time.timeScale = 1f;

        // set the game to not paused.
        game_is_paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // pause on escape.
        if(Input.GetKeyDown(KeyCode.Escape)) {

            // we are in the pause menu, so we want to resume.
            if(game_is_paused) {
                resume();
            }
            else {

                // pause the game
                pause();
            }
        }
    }
}
