using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Camera selfCamera;

    [SerializeField]
    private GameObject cameraObject;

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            CameraManager.SetCurrentCamera(selfCamera, cameraObject);
        }
            

    }

    

}
