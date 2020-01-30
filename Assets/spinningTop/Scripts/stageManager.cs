using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpinningTopGame {
    public class stageManager : MonoBehaviour
    {
        [SerializeField]
        public float gameDuration;

        [SerializeField]
        public bool started = false;

        [SerializeField]
        public GameObject top;

        int playerCount = 3;

        public KeyCode[,] playerKeyCodes; // [[r,g,b]]
        public int[,] playerColors;

        public float timeRemaining { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            // hardcode for now
            playerKeyCodes = new KeyCode[,]{
                {KeyCode.Z, KeyCode.X, KeyCode.C},
                {KeyCode.J, KeyCode.K, KeyCode.L},
                {KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow},
            };

            playerColors = new int[,]{
                {255, 0, 0},
                {0, 255, 0},
                {0, 0, 255},
            };
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                setPlayerCount(3);
                startGame();
            }
            
            updateTime();
        }

        void startGame() {
            started = true;
            timeRemaining = gameDuration;
            createPlayer();
        }

        void createPlayer() {
            for (int i = 0; i < playerCount; i++) {
                Vector2 playerLoc = Quaternion.Euler(0,0, i * 360 / playerCount) * new Vector2(0, 3);
                GameObject playerTop = Instantiate(top, playerLoc, Quaternion.Euler(0,0,0));
                spinningTop currentTop = playerTop.GetComponent<spinningTop>();
                currentTop.setKey(
                    playerKeyCodes[i,0],
                    playerKeyCodes[i,1],
                    playerKeyCodes[i,2]
                );
                currentTop.setPlayerColor(
                    playerColors[i, 0],
                    playerColors[i, 1],
                    playerColors[i, 2]
                );
            }
        }

        void updateTime() {
            if (started) {
                timeRemaining -= Time.deltaTime;
            }
        }

        void setPlayerCount(int count) {
            if (count <= 3 && count >= 1) {
                this.playerCount = count;
            } else {
                Debug.Log("Invalid player count: " + count.ToString() + " (valid for 1-3 players).");
            }
        }
    }
}