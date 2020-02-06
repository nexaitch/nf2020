using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpinningTopGame {
    public class soundManager : MonoBehaviour
    {
        [SerializeField]
        public stageManager manager;

        [SerializeField]
        AudioSource timesUpSource, endWarningSource, tutorialSource, mainBgmSource;
        
        bool soundStarted = false;
        bool timesUpPlayed = false;


        void Start() {
            tutorialSource.Play();
        }

        void Update() {
            countdownToStart();
            checkGameStart();
            checkWarning();
            checkTimesUp();
        }

        void checkGameStart() {
            if (manager.ready && !soundStarted) {
                tutorialSource.Stop();
                mainBgmSource.Play();
                soundStarted = true;
            }
        }

        void checkTimesUp() {
            if (manager.timeRemaining <= 0 && !timesUpPlayed && manager.started) {
                mainBgmSource.Stop();
                playTimesUp();
                timesUpPlayed = true;
            }
        }
        public void playTimesUp() {
            timesUpSource.time = 0.15f;
            timesUpSource.Play();
        }

        void countdownToStart() {
            if (manager.ready && !manager.started) {
                float warningOffset = 0.3f * (manager.countdownToStart % 1);
                if (warningOffset >= 0.29f) endWarningSource.Play();
            }
        }

        void checkWarning() {
            // calculation taken from UIManager
            if (manager.timeRemaining <= manager.warningTime && manager.timeRemaining > 0) {
                float warningOffset = 0.3f * (manager.timeRemaining % 1);
                if (warningOffset >= 0.29f) endWarningSource.Play();

                // tone down main bgm
                mainBgmSource.volume = 0.3f * (manager.timeRemaining / manager.warningTime);
            }
        }
    }
}