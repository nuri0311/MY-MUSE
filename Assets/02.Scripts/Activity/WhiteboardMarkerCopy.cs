using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WhiteboardMarkerCopy : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;

    /*private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;*/

    [SerializeField] public Renderer _renderer;
    [SerializeField] public Color[] _colors;
    [SerializeField] public float _tipHeight;
    
    [SerializeField] public RaycastHit _touch;
    [SerializeField] public Whiteboard _whiteboard;
    [SerializeField] public Vector2 _touchPos, _lastTouchPos;
    [SerializeField] public bool _touchedLastFrame;
    [SerializeField] public Quaternion _lastTouchRot;

    [SerializeField] public Whiteboard _displayboard;

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        //access to the color
        //coloring 5 by 5 square pixels
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    void Update()
    {
        // touching on whiteboard
        // change the pixel of whiteboard thar we particular touching
        Draw();
    }

    private void Draw(){
        if(Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight)){
            //actually touching the whiteboard?
            if(_touch.transform.CompareTag("Whiteboard")){ //checking whiteboard if the item is touching
                if(_whiteboard == null){
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y); //grab the touch position

                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize/2)); //convert the touch position
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize/2));

                var x2 = (int)(_touchPos.x * _displayboard.textureSize.x - (_penSize/2)); //convert the touch position
                var y2 = (int)(_touchPos.y * _displayboard.textureSize.y - (_penSize/2));

                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x ) return; //outside of the whiteboard pixel => exit (don't want to continue to draw)

                if(_touchedLastFrame){
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors); //setting the initial point
                    _displayboard.texture.SetPixels(x2, y2, _penSize, _penSize, _colors);

                    for(float f = 0.01f; f<1.00f; f += 0.01f){ //interpreting the last point in the current
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                        var lerpX2 = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY2 = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _displayboard.texture.SetPixels(lerpX2, lerpY2, _penSize, _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot; //locking the rotation that pen doesn't slapped

                    _whiteboard.texture.Apply(); //applying the coloration to the pixels
                    _displayboard.texture.Apply(); //applying the coloration to the pixels
                }

                //set the last frame items...
                //setting all the cashes from the last frame
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null; //uncashed the whiteboard
        _touchedLastFrame = false;
    }
}
