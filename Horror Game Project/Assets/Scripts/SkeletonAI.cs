using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;//The navmesh agent

    [SerializeField]
    private Animator animator;//The skeleton's animator

    [SerializeField]
    private Transform player;//A transform to follow

    [SerializeField]
    private float followRange;//A range to start pursuing the player


    

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(gameObject.transform.position, player.position) <= followRange){
            agent.SetDestination(player.position);
            animator.SetBool("IsPursuing", true);

        }else
            animator.SetBool("IsPursuing", false);
        
    }
}
