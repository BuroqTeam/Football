using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    #region Fields

    [Header("Component Settings")]
    public PlayerData PlayerDataSO;
    [SerializeField]
    private ArrowLineRenderer _arrowLineRenderer;
    [SerializeField]
    private CircleColorChanger _circleColor;
    [SerializeField]
    private CircleScaler _circleScaler;
    [SerializeField]
    private Vector3 _initialMousePosition;
    [SerializeField]
    private Vector3 _currentMousePosition;

    [SerializeField]
    private float _lengthOfMouseDrag;
    #endregion

    #region Interface methods
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.State.Equals(GameState.Targeting))
        {
            GetInitialDataOnBeginDrag();
            _arrowLineRenderer.SetFirstLineRendererPosition(_initialMousePosition);            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.State.Equals(GameState.Targeting))
        {
            GetCurrentDataOnDrag();
            _circleScaler.ScaleCircle(_lengthOfMouseDrag);
            _circleColor.ChangeColor(_lengthOfMouseDrag);
            _arrowLineRenderer.DrawLine(_lengthOfMouseDrag, PlayerDataSO.MaxCircleSize, _initialMousePosition, _currentMousePosition);            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        ResetInitialCondition();
    }
    #endregion

    #region Methods
    void GetInitialDataOnBeginDrag()
    {
        _initialMousePosition = transform.position;
    }

    void GetCurrentDataOnDrag()
    {
        _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentMousePosition = new Vector3(_currentMousePosition.x, _currentMousePosition.y, 0);
        _lengthOfMouseDrag = Vector3.Distance(_initialMousePosition, _currentMousePosition) * 2;
    }

    void ResetInitialCondition()
    {
        _circleScaler.ResetCircleInitialScale();
        _arrowLineRenderer.RemoveLine();
    }
    #endregion


}
