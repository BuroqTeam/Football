using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is responsible for change width and height of UI Image. 
/// </summary>
public class ImageSizeControl : MonoBehaviour
{
    private Image _image;
    private RectTransform _rectTransform;
    public Vector2 _initialSize;
    [SerializeField] private float _spriteWidth;
    [SerializeField] private float _spriteHeight;


    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
        _rectTransform = gameObject.GetComponent<RectTransform>();

        _initialSize = gameObject.GetComponent<RectTransform>().sizeDelta;
    }


    void Start()
    {
        ImageSizeChanger();
    }

        
    public void ImageSizeChanger()
    {
        _spriteWidth = _image.sprite.texture.width;
        _spriteHeight = _image.sprite.texture.height;
        ImageSizeFix();
    }


    /// <summary>
    /// Bo'yi va enining nisbati 1:1 bo'lmagan spritelar uchun imagening height va width ni tuzatadi. 
    /// </summary>
    void ImageSizeFix()
    {
        if (_spriteWidth > _spriteHeight)
        {
            float proportion = (float) _spriteWidth / _spriteHeight;
            //Debug.Log("width proportion " + proportion);
            _rectTransform.sizeDelta = new Vector2(_initialSize.x * proportion, _initialSize.y);
        }
        else if (_spriteWidth < _spriteHeight)
        {
            float proportion = (float)_spriteHeight / _spriteWidth;
            //Debug.Log("height proportion " + proportion);
            _rectTransform.sizeDelta = new Vector2(_initialSize.x, _initialSize.y * proportion);
        }
        else if (_spriteWidth == _spriteHeight)
        {
            //Debug.Log("Equal");
            _rectTransform.sizeDelta = _initialSize;
        }
    }


}
