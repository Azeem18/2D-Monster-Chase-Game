using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void restartGame(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void homeButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
