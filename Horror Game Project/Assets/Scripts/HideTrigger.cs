using UnityEngine;

public class HideTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject parentObjectToHide;

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            parentObjectToHide.SetActive(false);
        }
            

    }
}
