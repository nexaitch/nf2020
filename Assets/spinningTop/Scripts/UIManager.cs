using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpinningTopGame {
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        Text timeText;

        stageManager manager;
        // Start is called before the first frame update
        void Start()
        {
            manager = GetComponent<stageManager>();
        }

        // Update is called once per frame
        void Update()
        {
            updateTimeText();   
        }

        void updateTimeText() {
            if (manager.started) {
                timeText.text = "Time Left: " + manager.timeRemaining.ToString("F2");
            }
        }
    }
}