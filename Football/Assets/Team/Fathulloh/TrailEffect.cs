using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootBall
{
    /// <summary>
    /// Ballning ortidan trail qoldirish uchun qo'llaniladigan prefabni instantiate qiluvchi script.
    /// </summary>
    public class TrailEffect : MonoBehaviour
    {
        float timeBtwSpawns;
        public float startTimeBtwSpawns;

        public GameObject Echo;
        private BallMovement _ballMovement;
        float _destroyingTime = 2f;

        void Start()
        {
            _ballMovement = GetComponent<BallMovement>();
        }


        void Update()
        {
            if (_ballMovement.IsMoving)
            {
                if (timeBtwSpawns <= 0)
                {
                    GameObject instance = (GameObject)Instantiate(Echo, transform.position, Quaternion.identity);
                    Destroy(instance, _destroyingTime);
                    timeBtwSpawns = startTimeBtwSpawns;
                }
                else
                {
                    timeBtwSpawns -= Time.deltaTime;
                }
            }            
        }


    }
}
