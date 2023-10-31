using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Component Settings")]
    [SerializeField]
    private Transform _circleTransform;
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private Vector3 _initialMousePosition, _currentMousePosition;

    [Header("Circle Settings")]
    [SerializeField]
    [Range(1, 2.0f)]
    private float _maxCircleSize;
    [SerializeField]
    [Range(0, 2.0f)]
    private float _greenGap, _yellowGap;
    [SerializeField]
    [Range(0, 1.0f)]
    private float _alphaTransparency;

    [SerializeField]
    private float _lengthOfMouseDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.State.Equals(GameState.Targeting))
        {
            GetInitialDataOnBeginDrag();
            SetFirstLineRendererPosition();
        }            
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.State.Equals(GameState.Targeting))
        {
            GetCurrentDataOnDrag();
            ScaleUpCircle();
            ChangeCircleColor();            
            DrawArrowLine();
        }            
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        BackToInitialCondition();
    }

    void GetInitialDataOnBeginDrag()
    {
        _initialMousePosition = transform.position;
    }

    void SetFirstLineRendererPosition()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, _initialMousePosition);
    }

    void GetCurrentDataOnDrag()
    {
        _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentMousePosition = new Vector3(_currentMousePosition.x, _currentMousePosition.y, 0);
        _lengthOfMouseDrag = Vector3.Distance(_initialMousePosition, _currentMousePosition) * 2;
    }

    void BackToInitialCondition()
    {
        _circleTransform.localScale = new Vector3(0, 0, 0);
        _lineRenderer.positionCount = 0;
    }

    void ScaleUpCircle()
    {
        if (_lengthOfMouseDrag > 0 && _lengthOfMouseDrag <= _maxCircleSize)
        {
            Vector3 temp = _circleTransform.localScale;
            temp.x = _lengthOfMouseDrag / 0.6f;
            temp.y = _lengthOfMouseDrag / 0.6f;
            temp.z = 0;
            _circleTransform.localScale = temp;            
        }            
    }

    void ChangeCircleColor()
    {
        SpriteRenderer circle = _circleTransform.GetComponent<SpriteRenderer>();               
        if (_lengthOfMouseDrag > 0 && _lengthOfMouseDrag <= _greenGap)
        {
            circle.color = Color.green;
        }
        else if (_lengthOfMouseDrag > _greenGap && _lengthOfMouseDrag <= _yellowGap)
        {
            circle.color = Color.yellow;
        }
        else
        {
            circle.color = Color.red;
        }
        Color currentColor = circle.color;
        currentColor.a = _alphaTransparency;
        circle.color = currentColor;
    }

    void DrawArrowLine()
    {                                        
        if (_lengthOfMouseDrag / 2 >= _maxCircleSize)
        {
            Debug.Log("Salam");
            Vector3 startPoint = _lineRenderer.GetPosition(0);
            _lineRenderer.SetPosition(1, (2 * _initialMousePosition - _currentMousePosition));
            Vector3 endPoint = _lineRenderer.GetPosition(1);
            float ratio = _maxCircleSize / Vector3.Distance(startPoint, endPoint);
            float newX = startPoint.x + ratio * (endPoint.x - startPoint.x);
            float newY = startPoint.y + ratio * (endPoint.y - startPoint.y);
            float newZ = startPoint.z;            
            _lineRenderer.SetPosition(1, new Vector3(newX, newY, newZ));
        }
        else
        {
            _lineRenderer.SetPosition(1, (2 * _initialMousePosition - _currentMousePosition));
        }

    }
}
