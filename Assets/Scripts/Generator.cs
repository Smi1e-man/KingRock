using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;
    public GameObject enemy_4;

    GameObject pref;

    public float radius;

    public float SpawnDeltaTime;

    float deltaAngle = 20f;

    float nextTime;

	float _x;
    float _z;

    float angle;
    float old_angle;

    Vector3 direction;
    Quaternion lookRotate;


    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0f, 360f);
        old_angle = angle;

        SpawnEnemy(angle, RandEnemy());
        nextTime = Time.time + SpawnDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTime)
        {
			angle = Random.Range(0f, 360f);
            if ((angle > (old_angle + deltaAngle)) || (angle < (old_angle - deltaAngle)))
            {
                SpawnEnemy(angle, RandEnemy());
                old_angle = angle;
            }
            nextTime = Time.time + SpawnDeltaTime;
        }
    }

    void    SpawnEnemy(float angle, GameObject enemy)
    {
		
		_x = radius * Mathf.Cos(angle);
		_z = radius * Mathf.Sin(angle);
		
		pref = Instantiate(enemy, new Vector3(_x, 0f, _z), Quaternion.identity);
		
		direction = (Vector3.zero - pref.transform.position).normalized;
		lookRotate = Quaternion.LookRotation(direction);
		
		pref.transform.rotation = lookRotate;
    }

    GameObject   RandEnemy()
    {
        float nb = Random.Range(0, 4);

        if (nb == 0)
            return (enemy_1);
        else if (nb == 1)
            return (enemy_2);
        else if (nb == 2)
            return (enemy_3);
        else
            return (enemy_4);

    }

}
