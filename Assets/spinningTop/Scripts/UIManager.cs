﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpinningTopGame {
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        Text timeText, countdownText;

        [SerializeField]
        Text[] scoreTexts;

        [SerializeField]
        GameObject tutorialPanel, endWarningPanel, finishPanel, countdownPanel;


        [SerializeField]
        public stageManager manager;
        // Start is called before the first frame update
        void Start()
        {
            finishPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            updateTimeText();
            updateCountdownText();
            updateTutorialPanel();
            updateWarningPanel();
            updateFinishPanel();
            updateScores();
        }

        void updateTimeText() {
            if (manager.started && manager.timeRemaining > 0) {
                timeText.text = "Time Left: " + manager.timeRemaining.ToString("F2");
            } else {
                timeText.text = "";
            }
        }

        void updateCountdownText() {
            if (manager.ready && !manager.started) {
                countdownPanel.SetActive(true);
                countdownText.text = (Mathf.Ceil(manager.countdownToStart)).ToString();
                float textScale = manager.countdownToStart % 1;
                countdownText.rectTransform.localScale = new Vector3(textScale, textScale, 1);
            } else {
                countdownPanel.SetActive(false);
            }
        }

        void updateTutorialPanel() {
            if(manager.ready) {
                tutorialPanel.SetActive(false);
            }
        }

        void updateWarningPanel() {
            if(manager.started) {
                if (manager.timeRemaining < manager.warningTime) {
                    endWarningPanel.GetComponent<Image>().color = new Color(1, 0, 0, 0.3f * (manager.timeRemaining % 1));
                }
            }
        }

        void updateFinishPanel() {
            if(manager.started && manager.timeRemaining <= 0) {
                finishPanel.SetActive(true);
            }
        }

        void updateScores() {
            if(manager.started) {
                for (int i = 0; i < manager.playerCount; i++) {
                    if (manager.spawnedTops[i] != null) {
                        scoreTexts[i].text = "Score: " + manager.spawnedTops[i].score.ToString();
                    } else {
                        scoreTexts[i].text = "";
                    }
                }

            } else {
                foreach (Text scoreText in scoreTexts) {
                    scoreText.text = "";
                }
            }
        }
    }
}