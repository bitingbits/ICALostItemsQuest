using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

    //EnemyStats
    public int detectionRange;

    public int movementSpeed;


    public NavMeshAgent[] navAgents;
    protected GameObject[] pointList;

    public GameObject player;

    private enemyStateMachine SM;

    protected virtual void FSMStart() { }
    protected virtual void FSMUpdate() { }

    //private 
    //FindObjectsOfType<Agent>()

    // Use this for initialization
    void Start () {
     //   player = GameObject.Find("Player");
        navAgents = FindObjectsOfType(typeof(NavMeshAgent)) as NavMeshAgent[];
        foreach (NavMeshAgent agent in navAgents)
        {
            agent.speed = movementSpeed;
        }
        FSMStart();
	}
	
	// Update is called once per frame
	void Update () {
        FSMUpdate();
        if(isGrounded())
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,25,0));
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 2);
    }
}
