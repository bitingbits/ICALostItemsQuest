using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

    //EnemyStats
    public int detectionRange;

    public int movementSpeed;


    public NavMeshAgent navAgent;
    protected GameObject[] pointList;

    public GameObject player;

    private enemyStateMachine SM;

    protected virtual void FSMStart() { }
    protected virtual void FSMUpdate() { }

    //private 
    //FindObjectsOfType<Agent>()

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = movementSpeed;
        
        FSMStart();
	}
	
	// Update is called once per frame
	void Update () {
        FSMUpdate();
    }
}
