using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //обєкт слідування
    [SerializeField] GameObject followObject;


    // Оновлення після основного оновлення
    void LateUpdate()
    {
        transform.position = followObject.transform.position + new Vector3(0, 0, -10);
    }
}
