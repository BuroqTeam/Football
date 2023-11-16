using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FootBall
{
    public class GoalAction : MonoBehaviour
    {
        #region Fields
        public Image FadePanel;
        public TMP_Text ScoreAnimText;
        public GameEvent RestartEvent;
        public GameEvent StartEvent;
        #endregion



        void Start()
        {
            ScoreAnimText.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        


        public void GoalAnim()
        {
            StartCoroutine(GoalAnimation());
        }


        IEnumerator GoalAnimation()
        {
            FadePanel.raycastTarget = true;
            yield return new WaitForSeconds(1f);

            ScoreAnimText.gameObject.transform.DOScale(1.5f, 0.75f);
            yield return new WaitForSeconds(1f);

            ScoreAnimText.gameObject.transform.DOScale(0, 0.2f);
            FadePanel.DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.5f);

            RestartEvent.Raise();
            yield return new WaitForSeconds(0.7f);

            FadePanel.DOFade(0, 0.5f);
            yield return new WaitForSeconds(0.5f);

            FadePanel.raycastTarget = false;
            yield return new WaitForSeconds(0.5f);

            StartEvent.Raise();
            //GameManager.Instance.UpdateGameState(GameState.Idle);
            // Text animation
            // Text is invisible
            // Fade panel
            // Reset all thing
        }



    }
}
