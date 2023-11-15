using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FootBall
{
    public class GoalAction : MonoBehaviour
    {
        #region Fields
        public TMP_Text ScoreText;
        public TMP_Text ScoreAnimText;

        #endregion



        void Start()
        {

        }


        public void GoalAnim()
        {
            StartCoroutine(GoalAnimation());
        }


        IEnumerator GoalAnimation()
        {
            yield return new WaitForSeconds(0.5f);

            // Text animation
            // Text is invisible
            // Fade panel
            // Reset all thing
        }

    }
}
