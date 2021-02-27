using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Play(string LevelLabel)
    {
        SceneManager.LoadScene(LevelLabel);
    }

    public void Authors(Animator animator)
    {
        animator.SetBool("IsOpen", !animator.GetBool("IsOpen"));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
