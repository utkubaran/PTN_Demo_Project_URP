using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePainter : MonoBehaviour
{
    [SerializeField][Range(2, 512)]
    private int textureSize = 128;

    [SerializeField]
    private TextureWrapMode textureWrapMode;

    [SerializeField]
    private FilterMode filterMode;

    [SerializeField]
    private Texture2D texture;

    [SerializeField]
    private Material material;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Collider _collider;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private int _brushSize;

    private int paintedPixel, oldRayX, oldRayY;

    private float paintedWallPerct;

    private void OnValidate()
    {
        if (texture == null)
        {
            texture = new Texture2D(textureSize, textureSize);
        }

        if (texture.width != textureSize)
        {
            texture.Resize(textureSize, textureSize);
        }

        texture.wrapMode = textureWrapMode;
        texture.filterMode = filterMode;
        material.mainTexture = texture;
        texture.Apply();
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (_collider.Raycast(ray, out hit, 100f))
            {
                int rayX = (int)(hit.textureCoord.x * textureSize);
                int rayY = (int)(hit.textureCoord.y * textureSize);

                if ( oldRayX != rayX || oldRayY != rayY)
                {
                    // DrawQuad(rayX, rayY);
                    DrawCircle(rayX, rayY);
                    oldRayX = rayX;
                    oldRayY = rayY;
                }

                texture.Apply();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log(paintedPixel);
            Debug.Log((float)paintedPixel / (float)(textureSize*textureSize));
        }

        Debug.Log((float)paintedPixel / (float)(textureSize*textureSize));
    }

    private void DrawQuad(int rayX, int rayY)
    {
        for (int y = 0; y < _brushSize; y++)
        {
            for (int x = 0; x < _brushSize; x++)
            {
                texture.SetPixel(rayX + x - _brushSize / 2, rayY + y - _brushSize / 2, _color);
            }
        }
    }

    private void DrawCircle(int rayX, int rayY)
    {
        for (int y = 0; y < _brushSize; y++)
        {
            for (int x = 0; x < _brushSize; x++)
            {
                float x2 = Mathf.Pow(x - _brushSize / 2, 2);
                float y2 = Mathf.Pow(y - _brushSize / 2, 2);
                float r2 = Mathf.Pow(_brushSize / 2 - 0.5f, 2);

                if (x2 + y2 < r2)
                {
                    int pixelX = rayX + x - _brushSize / 2;
                    int pixelY = rayY + y - _brushSize / 2;

                    if (pixelX >= 0 && pixelX < textureSize && pixelY >= 0 &&  pixelY < textureSize)
                    {
                        Color oldColor = texture.GetPixel(pixelX, pixelY);
                        // Color resultColor = Color.Lerp(oldColor, _color, _color.a);

                        if (oldColor != _color)
                        {
                            texture.SetPixel(rayX + x - _brushSize / 2, rayY + y - _brushSize / 2, _color);
                            paintedPixel++;
                        }
                    }
                }
            }
        }
    }
}
