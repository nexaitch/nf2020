using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpinningTopGame {
    public class Goal : MonoBehaviour
    {

        [SerializeField]
        public uint scorePoint = 10;
        public stageManager manager;
        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            spinningTop top = col.GetComponent<spinningTop>();
            if (top != null) {
                top.score += scorePoint;
                Destroy(this.gameObject);
                manager.spawnGoal();
            }
        }
    }

}
