using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public int chestTotalWheat;
    public Text wheatText;
    public Canvas chestUI;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            chestUI.enabled = true;
            animator.SetBool("open", true);
            animator.SetBool("closed", false);
        }
        //chestUI.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player)
        {
            chestUI.enabled = false;
            animator.SetBool("closed", true);
            animator.SetBool("open", false);
        }
    }
    
    public void StorageItems(){
        if (Player.instance.totalWheat > 0)
        {
            chestTotalWheat += Player.instance.totalWheat;
            Player.instance.totalWheat = 0;
            wheatText.text = chestTotalWheat.ToString();
        }
    }

}
