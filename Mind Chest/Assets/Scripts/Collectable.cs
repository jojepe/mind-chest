using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Animator animator;
    public float timePassed;
    public float timeToGrow;
    public bool readyToCrop = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timePassed < timeToGrow + 1){
            if (timePassed > timeToGrow/4)
            {
                animator.SetBool("grow1", true);
            }
            if (timePassed > timeToGrow/2)
            {
                animator.SetBool("grow2", true);
            }
            if (timePassed == timeToGrow)
            {
                animator.SetBool("grow3", true);
                readyToCrop = true;
            }
        }
    }

    private void OnEnable()
    {
        if(timePassed < timeToGrow + 1){
            TimeManager.OnHourChanged += UpdateTime;
        }
    }

    private void UpdateTime()
    {
        if(timePassed <= timeToGrow){
            timePassed += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player && readyToCrop)
        {
            Player.instance.totalWheat += 1;
            Player.instance.selectedObject.GetComponent<CropManager>().hasSeed = false;
            Player.instance.selectedObject.GetComponent<CropManager>().durationCycle--;
            Destroy(gameObject);
        }
    }
}
