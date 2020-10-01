using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    Vector3 testpos;
    void Start()
    {
        testpos = transform.position;
        print(testpos);

        testpos = new Vector3(0f, 10f, 0f);
        print(testpos);

    }

    void Update()
    {

    }
}
