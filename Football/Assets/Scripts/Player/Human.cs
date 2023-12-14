using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FootBall
{
    /// <summary>
    /// This script is responsible for change Sport suit and human face.
    /// </summary>
    public class Human : MonoBehaviour
    {
        public Sprite[] PlayerBodies;
        public Sprite[] SportUniforms;
        public Sprite[] GoalKeeperUniforms;

        [SerializeField] private SpriteRenderer _bodySpriteRenderer;
        [SerializeField] private SpriteRenderer _uniformSpriteRenderer;
        
        public TeamListSO TeamList;

        private GameObject _parentObject;

        void Start()
        {
            _parentObject = gameObject.transform.parent.gameObject;            
            SetPlayerBody();
            SetPlayerUniform();
        }

        
        void SetPlayerBody()
        {
            int rand = Random.Range(0, PlayerBodies.Length);
            _bodySpriteRenderer.sprite = PlayerBodies[rand];
        }


        void SetPlayerUniform()
        {
            Player _player = _parentObject.GetComponent<Player>();

            if (_player.IsGoalKeeperPlayer)
            {
                int rand = Random.Range(0, GoalKeeperUniforms.Length);
                _uniformSpriteRenderer.sprite = GoalKeeperUniforms[rand];
            }
            else
            {

            }
        }

    }
}
