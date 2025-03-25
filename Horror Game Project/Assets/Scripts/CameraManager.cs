using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField]
    private Camera startCamera;

    static Camera currentCamera;

    static GameObject currentCameraObject;

    void Start(){
        currentCamera = startCamera;
        

    }
    public static void SetCurrentCamera(Camera c, GameObject g){
        //Hides the current camera
        currentCamera.enabled = false;
        if(currentCameraObject != null)
        currentCameraObject.SetActive(false);

        //Assigns values of new camera object
        currentCamera = c;
        currentCameraObject = g;

        //Reactivates new camera 
        currentCamera.enabled = true;
        currentCameraObject.SetActive(true);
        

    }
}
