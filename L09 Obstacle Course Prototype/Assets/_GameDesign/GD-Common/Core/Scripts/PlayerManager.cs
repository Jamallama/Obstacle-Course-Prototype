using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Spidergram
{

    [RequireComponent(typeof(AudioSource))]

    public class PlayerManager : MonoBehaviour
    {
        /*
         * Alejandro Jauco
         * 
         * derived from PlayerManager1
         * 10/7/2022
         * Uses a different Lose and Win method
         * 11/10/2023 Added Lives. time ends then decrement Lives. LivesDecrement() resets the player
         */
        //

        public int Lives = 3;
        private int LivesMax;

        public bool usePortal = false;  // change this if you want to require player to get out of level with portal

        public bool useDisableFPC = false;  //turn off the FPC
        public bool useUntagPlayer = true;  // will untag the player if lose condition

        public float hp = 100;  // 0 = dead
        public float maxHP = 200;
        public float winpoints = 100f;   // score this and you are a winner
        public float startpoints = 0; // start with something greater than lose value

        // private float losevalue = -1;

        /// GUIText scoretext;  // Old Gui system
        public Text Scoretext;
        public Text Healthtext;
        public Text statusText;
        public Text timeText;
        public Text LivesText;  // used for lives
        public float timeShowTimeValue = 180f;  // 10 secs, display time left once time is nearing lose condition
        public float timeLimit = 180f;  // must finish all before time runs out!
        public bool resetTime = false;

        private float timeCountdown;

        public bool areTasksDone;


        public string timeString = "Timeout. You Lose";  // timer goes to zero what happens? Do you win or lose?

        [SerializeField]
        private GameObject WinObject;  // enabled
        [SerializeField]
        private GameObject LoseObject;

        // public string pickupTag = "Pick Up";
        //public string pickupName = "Coin";

        private AudioSource asrc;
        public AudioClip hitclip;  // sound when player hit
        public AudioClip winclip;  // sound when player wins
        public AudioClip loseclip;  // sound when player loses


        public float volume = 1f;  // the volume 0 - 1.0
        public bool showCursor = false;  // set to true to force showing the cursor.


        static float winstatus = 0; //  1=win, -1=lose, 0=nothing

        public float total = 0;
        public KeyCode restartKey = KeyCode.T;

        void CursorReset()
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1.0f;

        }

        void ResetPlayer()
        {
            winstatus = 0;
            total = 0;
            ResetPoints();
            ScorePoints(0);
            if (Healthtext)
                Healthtext.text = " " + hp;

            // AMJ timeCountdown = timeLimit;
            if (timeText != null)
                timeText.text = "";
            //BMJ if (timeText != null)
            //    timeText.text = timeCountdown.ToString("#");
            if (statusText != null)
                statusText.text = "";
            if (showCursor)
                CursorReset();

            if (LivesText)
                LivesText.text = "Lives: " + Lives;

        }

        void Restart()
        {
            timeCountdown = timeLimit;
            ResetPlayer();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        void Start()
        {
            LivesMax = Lives;

            if (LivesText)
                LivesText.text = "Lives: " + Lives;

            if (LoseObject != null)
            {

                LoseObject.SetActive(false);
                
            }
            if (WinObject != null)
            {
                WinObject.SetActive(false);                

            }
            areTasksDone = false;
            asrc = GetComponent<AudioSource>();

            timeCountdown = timeLimit;
            ResetPlayer();
            Debug.Log("Win Points is " + winpoints);
        }


        public void ScorePoints(int inpoints)
        {
            total += inpoints;


            if (Scoretext)
            {
                Scoretext.text = " " + total;
                if (total >= winpoints)
                {
                    total = winpoints;
                }
            }
            Debug.Log("Player: Score " + inpoints + " Total " + total);

        }

        public void TakeDamage(int inpoints)
        {
            hp = hp - inpoints;

            if (Healthtext)
            {
                Healthtext.text = " " + hp;
                if (hp <= 0)
                {
                    hp = 0;
                    Healthtext.text = " " + hp;
                    if (useUntagPlayer)
                        gameObject.tag = "Untagged";
                }
            }
            if (asrc && hitclip)
            {
                Debug.Log("HIT Sound");
                asrc.PlayOneShot(hitclip);
            }
            Debug.Log("Player: HP " + inpoints);
            return;
        }

        public void disableFPC()
        {
            /*
            FirstPersonController fpc = GetComponent<FirstPersonController>();
            if (fpc)
            {
                fpc.enabled = false;
            }
            */
        }

        public void enableFPC()
        {
            /*
            FirstPersonController fpc = GetComponent<FirstPersonController>();
            if (fpc)
            {
                fpc.enabled = true;
            }
            */
        }



        public void AddHealth(int inpoints)
        {
            hp = hp + inpoints;
            hp = Mathf.Min(hp, maxHP);

            if (Healthtext)
            {
                Healthtext.text = " " + hp;
                if (hp <= 0)
                {
                    hp = 0;
                    gameObject.tag = "Untagged";
                }
            }
            Debug.Log("Player: HP " + inpoints);
        }


        public void HealthPoints(int inpoints)
        {
            TakeDamage(inpoints);
        }

        public void AddKey1(int points)
        {

        }

        public void ResetPoints()
        {
            total = startpoints;
        }

        void PlayWinSound()
        {
            if (asrc && winclip)
            {
                Debug.Log("WIN Sound");
                asrc.PlayOneShot(winclip);
            }
        }

        void PlayLoseSound()
        {
            if (asrc && loseclip)
            {
                Debug.Log("Lose Sound");
                asrc.PlayOneShot(loseclip);
            }
        }

        void CheckWin()
        {

            // if ((total >= winpoints) || areTasksDone)
            if (total >= winpoints)
            {
                winstatus = 1;

                string winstr = "YOU WIN";
                Debug.Log(winstr);
                Debug.Log("T " + total + " " + winpoints);
                if (statusText != null)
                    statusText.text = winstr;
                PlayWinSound();

                if (useDisableFPC)
                    disableFPC();


                if (WinObject != null)
                {
                    WinObject.SetActive(true);
                    // Debug.Log("WIN OBJECT");

                }

            }
        }

        void CheckLose()
        {
            // if (total <= losevalue)
            /*
            if (timeLimit > 0 && timeCountdown <= 0)
            {
                winstatus = -1;  // lose
                Debug.Log("Time ran out");


                PlayLoseSound();

                if (useDisableFPC)
                    disableFPC();

                if (LoseObject != null)
                    LoseObject.SetActive(true);
            }

                        if (hp <= 0)
                        {
                            Debug.Log("YOU Lose");
                            winstatus = -1;
                            if (LoseObject != null)
                                LoseObject.SetActive(true);
                        }
            */
            if (timeLimit > 0 && timeCountdown <= 0)
            {
                Debug.Log("Time ran out");
                LivesDecrement();

            }

            if (hp <= 0)
            {
                Debug.Log("Out of health");
                LivesDecrement();
            }

            if (Lives <= 0)
            {
                Debug.Log("No more lives. You Lose");
                winstatus = -1;


                PlayLoseSound();

                if (useDisableFPC)
                    disableFPC();


                if (LoseObject != null)
                    LoseObject.SetActive(true);
            }
        }

        void OnDestroy()
        {
            Time.timeScale = 1.0f;  // always reset the timeScale
                                    // Debug.Log("OnDestroy timeScale=" + Time.timeScale);
        }

        void Update()
        {
            if (Input.GetKeyDown(restartKey))
            {
                Restart();
            }
            if (winstatus != 0)
                return;


            CheckWin();
            CheckLose();
            if (winstatus != 0)
            /* winstatus == 0 is neutral, winstatus = 1 is win, winstatus < 1 is lose */
            {

            }
        }

        private void FixedUpdate()
        {

            if (timeCountdown > 0f)
                timeCountdown -= Time.fixedDeltaTime;

            if (timeCountdown <= 0f)
            {
                timeCountdown = 0f;
                if (statusText)
                    statusText.text = timeString;
                return;
            }
            if (timeText && timeCountdown <= timeShowTimeValue + 0.01f)
                timeText.text = Mathf.FloorToInt(timeCountdown + 0.5f).ToString();
            //Debug.Log("Time: " + Mathf.FloorToInt(timeCountdown + 0.5f).ToString());

            //BMJ if (timeText != null)
            //    timeText.text = timeCountdown.ToString("#");
        }

        void OnGUI()
        {/* AMJ needs debugging
            if (winstatus > 0)
            {
                CheckWin();
                return;
            }
            */

            if (winstatus != 0 && !usePortal)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;

                if (useDisableFPC)
                    disableFPC();

                timeCountdown = 0; // reset the time
                if(timeText != null)
                    timeText.text = timeCountdown.ToString("#");

                if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 20, 200, 30), restartKey.ToString() + " to Restart"))
                {
                    if (useDisableFPC)
                        enableFPC();

                    Time.timeScale = 1.0f;
                    // Screen.lockCursor = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;

                    Debug.Log("Restart");
                    winstatus = 0;
                    timeCountdown = timeLimit;
                    ResetPlayer();

                    string currentSceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(currentSceneName);
                }
            }
        }

        void OnCollisionEnter(Collision col)
        {

            if (col.gameObject.tag == "Bullet")
            {
                Debug.Log("Collision " + col.gameObject.tag);
            }
        }

        public void TasksCompleted()
        {
            areTasksDone = true;
        }

        public void LivesDecrement()
        {
            Lives--;
            Lives = (Lives < 0) ? 0 : Lives;

            if (Lives <= 0)
                timeCountdown = 0;
            else
            {
                if (resetTime)
                    timeCountdown = timeLimit;
                ResetPlayer();

                this.gameObject.SendMessage("LoadCheckPoint", SendMessageOptions.DontRequireReceiver);
                // this.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
            }

            Debug.Log("Lives: " + Lives);

            if (LivesText)
                LivesText.text = "Lives: " + Lives;

        }
        public void LivesIncrement()
        {
            ++Lives;
            Lives = (Lives > LivesMax) ? LivesMax : Lives;

            Debug.Log("Lives: " +  Lives);

            if (LivesText)
                LivesText.text = "Lives: " + Lives;

        }


    }
}