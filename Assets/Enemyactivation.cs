using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyactivation : MonoBehaviour
{
    #region Spawns
    public Transform[] SpawnPoint;
    #endregion

    #region Enemy
    public GameObject Enemy;
    public GameObject[] EnemyManager;
    #endregion

    #region EnemyActivation
    public string Spawn;
    public string Movement;
    #endregion

    #region HasActivated
    bool HasActivatedSpawn = false;
    bool HasActivatedMovement = false;
    #endregion

    #region Movement & Speed
    public float Speed = 0.1f;
    public float rotationSpeed = 3;
    #endregion

    #region Walls
    public GameObject SpawnWall;
    public GameObject MovementWall;
    #endregion

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }
        if (HasActivatedSpawn)
        {
            SpawnWall.SetActive(false);
        }
        if (HasActivatedMovement)
        {
            MovementWall.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == Spawn && !HasActivatedSpawn)
        {
            HasActivatedSpawn = true;
            for (int i = 0; i <= 3; i++)
            {
                Instantiate(Enemy, SpawnPoint[i].transform.position, SpawnPoint[i].transform.rotation);
            }
        }
        if (col.gameObject.tag == Movement && !HasActivatedMovement)
        {
            HasActivatedMovement = true;
            EnemyManager = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemies in EnemyManager)
            {
                enemies.transform.Translate(1, 0, 0);
            }
        }
    }
}
