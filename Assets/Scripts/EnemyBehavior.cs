using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    public Transform Player;
    private NavMeshAgent _agent;
    public Transform PatrolRoute;
    public List<Transform> Locations;

    private int _locationIndex = 0;

    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }
        private set {
            _lives = value;

            if(_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();

        Player = GameObject.Find("Player").transform;
        
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex +1) % Locations.Count;
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute) { 
        Locations.Add(child);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            _agent.destination = Player.position;
            Debug.Log("Player detected - attack!");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player out of range ,resume patrol");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical hit");
        }
    }

}
