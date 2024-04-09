using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Spidergram
{

    /*
     * Alejandro Jauco
     * 4/26/2023 Added  Restart() NextLevel() QuitGame()
     * 
     * */

    public class PlayMenuScene : MonoBehaviour
    {


        public int SceneNum = 1;

        public void PlayScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneNum);
        }
        public void Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        public void NextLevel()
        {
            int next = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
            int count = UnityEngine.SceneManagement.SceneManager.sceneCount;

            next = (next >= count ) ? 0: next;

            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}