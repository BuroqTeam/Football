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
        private Player _player;

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
            _player = _parentObject.GetComponent<Player>();
            
            if (_player.CurrentTeam.ToString() == "FirstTeam")
            {
                int spriteIndex = PlayerPrefs.GetInt("FirstTeamIndex");
                //Debug.Log("spriteIndex = " + spriteIndex);
                if (_player.IsGoalKeeperPlayer)                
                    _uniformSpriteRenderer.sprite = TeamList.GoalKeeperUniforms[spriteIndex];                
                else
                    _uniformSpriteRenderer.sprite = TeamList.TeamUniforms[spriteIndex];               
            }
            else if(_player.CurrentTeam.ToString() == "SecondTeam")
            {
                int spriteIndex = PlayerPrefs.GetInt("SecondTeamIndex");
                //Debug.Log("spriteIndex = " + spriteIndex);
                if (_player.IsGoalKeeperPlayer)                
                    _uniformSpriteRenderer.sprite = TeamList.GoalKeeperUniforms[spriteIndex];                
                else
                    _uniformSpriteRenderer.sprite = TeamList.TeamUniforms[spriteIndex];               
            }
        }

    }
}
