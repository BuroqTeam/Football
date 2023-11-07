using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FootBall
{
    public class UIManager : MonoBehaviour
    {


        public void ExitApplication()
        {
            Application.Quit();
            
        }

        public void LoadGame()
        {
            SceneManager.LoadScene("Game 1");
        }


        
    }


}
