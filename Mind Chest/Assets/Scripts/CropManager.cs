using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private bool random;
    
    public SpriteRenderer sr;
    public Sprite naturalSprite;
    public Sprite plowedSprite;
    
    public bool isSelected;
    public bool isReady;
    public bool hasSeed;
    public int durationCycle = 3;
    
    public static CropManager instance;
    
    

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (durationCycle == 0)
        {
            sr.sprite = naturalSprite;
            isReady = false;
            durationCycle = 3;
        }
        if(Input.GetKeyDown(KeyCode.Space) && isSelected)
        {
            print("before plow = " + isReady);
            if(isReady && !hasSeed)
            {
                Plant();
            }
            if (!isReady)
            {
                Plowing();
                print("after plow = " + isReady);
            }
        }
    }
    
    public void Plowing()
    {
        sr.sprite = plowedSprite;
        isReady = true;
    }

    public void Plant()
    {
        OnSpawnPrefab();
        hasSeed = true;
    }

    public void OnSpawnPrefab()
    {
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
    }

}
