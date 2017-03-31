using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour {
    public float orthographicSize = 5;
    public float aspect = 1.33333f;
    // Use this for initialization
   
    void Start () {
        Camera thisCamera = GetComponent<Camera>();
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
               -orthographicSize * aspect, orthographicSize * aspect,
               -orthographicSize, orthographicSize,
               thisCamera.nearClipPlane, thisCamera.farClipPlane);
    }
    
   
    // Update is called once per frame
    void Update () {
		
	}
}
