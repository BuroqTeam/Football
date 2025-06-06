using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FootBall
{
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        #region Fields

        [Header("Component Settings")]
        public PlayerData PlayerDataSO;
        [SerializeField]
        private ArrowLineRenderer _arrowLineRenderer;
        [SerializeField]
        private SniperLineRenderer _sniperLineRenderer;
        [SerializeField]
        private CircleColorChanger _circleColor;
        [SerializeField]
        private CircleScaler _circleScaler;
        [SerializeField]
        private Vector3 _initialMousePosition;
        [SerializeField]
        private Vector3 _currentMousePosition;
        private Player _player;
        [HideInInspector] public bool _IsDragged = false;
        public StringVariable GoalKeeperSO;


        private void Awake()
        {
            _player = GetComponent<Player>();            
        }

        private void Update()
        {
            if (!_player.IsEnable && _IsDragged) // This is work when time is over
            {
                _arrowLineRenderer.RemoveLine();
                ResetInitialCondition();
                _IsDragged = false;
            }
            

            if (_player.IsGoalKeeperPlayer && _player.IsEnable)
            {
                if (_IsDragged)
                {
                    if (gameObject.transform.position.x > 0)
                    {
                        GoalKeeperSO.Value = ("right");
                    }
                    else if (gameObject.transform.position.x < 0)
                    {
                        GoalKeeperSO.Value = ("left");
                    }
                }
                else if (!_IsDragged)
                {
                    GoalKeeperSO.Value = ("null");
                }
            }
        }

        public float LengthOfMouseDrag;
        #endregion

        #region Interface methods
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (GameManager.Instance.CurrentState.Equals(GameState.Idle) && _player.IsEnable)
            {
                _IsDragged = true;
                GetInitialDataOnBeginDrag();
                _arrowLineRenderer.SetFirstLineRendererPosition(_initialMousePosition);
                _sniperLineRenderer.SetFirstLineRendererPosition(_initialMousePosition);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (GameManager.Instance.CurrentState.Equals(GameState.Idle) && _player.IsEnable)
            {
                GetCurrentDataOnDrag();
                _circleScaler.ScaleCircle(LengthOfMouseDrag * 2);
                _circleColor.ChangeColor(LengthOfMouseDrag * 2);
                _arrowLineRenderer.DrawLine(LengthOfMouseDrag, PlayerDataSO.MaxCircleSize, _initialMousePosition, _currentMousePosition);
                _sniperLineRenderer.DrawSniperLine();
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (LengthOfMouseDrag > PlayerDataSO.minimumKickForce && _player.IsEnable)
            {
                GameManager.Instance.UpdateGameState(GameState.BallMoving);
            }
            else
            {
                GameManager.Instance.UpdateGameState(GameState.Idle);
                _arrowLineRenderer.RemoveLine();
            }
            ResetInitialCondition();

            if (_player.IsGoalKeeperPlayer)
            {
                GoalKeeperSO.Value = ("null");
            }            
        }
        #endregion

        #region Methods
        void GetInitialDataOnBeginDrag()
        {
            _initialMousePosition = transform.position;
        }

        void GetCurrentDataOnDrag()
        {
            LengthOfMouseDrag = 0;
            _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _currentMousePosition = new Vector3(_currentMousePosition.x, _currentMousePosition.y, 0);
            LengthOfMouseDrag = Vector3.Distance(_initialMousePosition, _currentMousePosition);
            if (LengthOfMouseDrag >= PlayerDataSO.MaxCircleSize)
            {
                LengthOfMouseDrag = PlayerDataSO.MaxCircleSize;
            }
        }

        void ResetInitialCondition()
        {
            _circleScaler.ResetCircleInitialScale();
            _currentMousePosition = Vector3.zero;

            _IsDragged = false;
            _sniperLineRenderer.RemoveLine();
            _arrowLineRenderer.ResetArrowPos();
        }

        public void ResetForIdle()
        {
            LengthOfMouseDrag = 0;
        }
        #endregion


    }


}

