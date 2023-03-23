using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Vector2Int _textureSize = new Vector2Int(2048, 2048);
    public Texture2D _texture;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        _texture = new Texture2D(_textureSize.x, _textureSize.y);
        renderer.material.mainTexture = _texture;
    }

    
}
