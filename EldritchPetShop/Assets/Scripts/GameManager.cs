using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    public GameObject maxMovementArea;
    public GameObject minMovementArea;
    public GameObject doorToWorld;
    public GameObject circleToCult;


    void Start()
    {

    }

    private void OnDrawGizmos()
    {

    }

    public Vector3 GenerateRandomWanderPoint()
    {
        return new Vector3(
            Random.Range(minMovementArea.transform.position.x, maxMovementArea.transform.position.x),
            Random.Range(minMovementArea.transform.position.y, maxMovementArea.transform.position.y),
            0
            );
    }

}


