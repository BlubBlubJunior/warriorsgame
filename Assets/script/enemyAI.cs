 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatisground, whatisplayer;

    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    
    public float timebetweenattacks;
    bool alreadyattacked;

    public float sightrange, attackrange;
    public bool playerinsightrange, playerinattackrange;

    private void awake()
    {
        player = GameObject.Find("man").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        playerinsightrange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);
        playerinattackrange = Physics.CheckSphere(transform.position, attackrange, whatisplayer);

        if (!playerinsightrange && !playerinattackrange) patroling();
        if (playerinsightrange && !playerinattackrange) chaseplayer();
        if (playerinsightrange && playerinattackrange) attackplayer();
    }
    private void patroling()
    {
        if (!walkpointset) searchwalkpoint();

        if (walkpointset)
            agent.SetDestination(walkpoint);

        Vector3 distancetowalkpoint = transform.position - walkpoint;

        if(distancetowalkpoint.magnitude < 1f)
        {
            walkpointset = false;
        }
    }
    private void searchwalkpoint()
    {
        float randomz = Random.Range(-walkpointrange, walkpointrange);
        float randomx = Random.Range(-walkpointrange, walkpointrange);

        walkpoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);

        if(Physics.Raycast(walkpoint, -transform.up, 2f, whatisground)) 
            walkpointset = true;
            
    }
    private void chaseplayer()
    {
        agent.SetDestination(player.position);
    }
    private void attackplayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyattacked)
        {
            alreadyattacked = true;
            Invoke(nameof(resetattack), timebetweenattacks);
        }
    }
    private void resetattack()
    {
        alreadyattacked = false;
    }
}
