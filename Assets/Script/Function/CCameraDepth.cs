using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CCameraDepth : MonoBehaviour
{
    public Material mat;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.DepthNormals;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
        /*
        if (onoff == 0)
        {
            Graphics.Blit(src, dest);
            return;
        }
        else
        {
            Graphics.Blit(src, dest, mat);
            return;
        }
        */
    }
}
