using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Transform t;
    float cx, cz;
    float speed;
    [SerializeField]
    float starting_speed;
    [SerializeField]
    float speed_changing_ratio;
    [SerializeField]
    Animator wing;
    bool fall = false;

    void Start()
    {
        t = gameObject.transform;
        Debug.Log(t.position.y);
        cx = t.position.x;
        cz = t.position.z;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            //ekrana týklama olayý
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                speed = starting_speed;
                fall = false;
            }
        }
        if(speed > 0 && !fall)
        {
            wing.SetBool("wing_up", false);
            t.position = new Vector3(cx, t.position.y + speed, cz);
            speed -= speed_changing_ratio;
            if(speed <= 0)
            {
                fall = true;
            }
        } 
        if (fall)
        {
            wing.SetBool("wing_up", true);
            t.position = new Vector3(cx, t.position.y - speed, cz);
            speed += speed_changing_ratio;
        }
    }
}
