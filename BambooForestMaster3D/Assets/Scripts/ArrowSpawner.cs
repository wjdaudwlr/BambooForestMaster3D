 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

enum Pattern
{
    Base,            // 窍唱 究 积己
    Circle,          // 盔屈栏肺 积己
    StraightLine,    // 老磊肺 积己   
}

enum StraightLineDirection
{
    Up,
    Down,
    Left,   
    Right
}

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField][Range(0f, 50f)] private float radius = 1;

    private float runningTime = 0;
    private Vector3 newPos = new Vector3();

    [SerializeField]
    PlayerController playerController;
    
    IEnumerator Start()
    {
        Debug.Log("START");
        StartCoroutine(ArrowPatternStart(1.5f, Pattern.Base));

        yield return new WaitForSeconds(10f);

        StartCoroutine(ArrowPatternStart(5f, Pattern.Circle));

        yield return new WaitForSeconds(10f);

        StartCoroutine(ArrowPatternStart(7, Pattern.StraightLine));
    }

    private void Update()
    {
        if(GameManager.Instance.gState == GameState.GameOver)
            StopAllCoroutines();
    }



    IEnumerator ArrowPatternStart(float delayTime, Pattern pattern)
    {
        ArrowPattern(pattern);
        yield return new WaitForSeconds(delayTime);

        StartCoroutine(ArrowPatternStart(delayTime, pattern));
    }

    void ArrowPattern(Pattern pattern)
    {
        float x;
        float z;
        Arrow newObj;

        switch (pattern)
        {
            case Pattern.Base:
                runningTime = UnityEngine.Random.Range(0, 60);
                x = radius * Mathf.Cos(runningTime);
                z = radius * Mathf.Sin(runningTime);
                newPos = new Vector3(x, 0, z);

                newObj = ObjectPool.GetObject();

                newObj.transform.position = newPos;
                newObj.Shoot((playerController.transform.position - newObj.transform.position)
                    + new Vector3(UnityEngine.Random.Range(-2f, 2f), 0, 0), true);
                break;

            case Pattern.Circle:
                for(int i = 0; i < 11; i++)
                {
                    runningTime = i * 12;
                    x = radius * Mathf.Cos(runningTime);
                    z = radius * Mathf.Sin(runningTime);
                    newPos = new Vector3(x, 0, z);

                    newObj = ObjectPool.GetObject();
                    newObj.transform.position = newPos;
                    newObj.Shoot((playerController.transform.position - newObj.transform.position), true);
                }
                break;

            case Pattern.StraightLine:
                StraightLinePattern(RandomEnum<StraightLineDirection>());
                break;
        }

    }


    private void StraightLinePattern(StraightLineDirection direction)
    {
        Arrow newObj;


        switch (direction)
        {
            case StraightLineDirection.Left:
                for (int i = -24; i <= 24; i += 3)
                {
                    newPos = new Vector3(47, 0, i);

                    newObj = ObjectPool.GetObject();
                    newObj.transform.position = newPos;
                    newObj.Shoot(Vector3.left);
                }
                break;

            case StraightLineDirection.Right:
                for (int i = -24; i <= 24; i += 3)
                {
                    newPos = new Vector3(-47, 0, i);

                    newObj = ObjectPool.GetObject();
                    newObj.transform.position = newPos;
                    newObj.Shoot(Vector3.right);
                }
                break;

            case StraightLineDirection.Up:
                for (int i = -24; i <= 24; i += 3)
                {
                    newPos = new Vector3(i, 0, 47);

                    newObj = ObjectPool.GetObject();
                    newObj.transform.position = newPos;
                    newObj.Shoot(new Vector3(0, 0, -1));
                }
                break;

            case StraightLineDirection.Down:
                for (int i = -24; i <= 24; i += 3)
                {
                    newPos = new Vector3(i, 0, -47);

                    newObj = ObjectPool.GetObject();
                    newObj.transform.position = newPos;
                    newObj.Shoot(new Vector3(0, 0, 1));
                }
                break;
        }
    }


    public static T RandomEnum<T>()
    {

        Array values = Enum.GetValues(typeof(T));

        return (T)values.GetValue(new System.Random().Next(0, values.Length));

    }



}
