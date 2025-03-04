using UnityEngine;
using UnityEngine.AI;

public class DisableXZ : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //  Tắt update Rotation để tránh xoay nhân vật không mong muốn
        agent.updateRotation = false; 

        //  Chỉnh Up Axis sang trục Z (để hoạt động đúng trong game 2D)
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
