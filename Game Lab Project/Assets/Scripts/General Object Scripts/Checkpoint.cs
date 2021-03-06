﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Sprite inactiveSprite;
    public Sprite activeSprite;

    private PlayerStatistics playerStatistics;

    //This is just so at the initial load-in we can create a 'Checkpoint' that they can respawn at rather than resetting the scene
    //Too bad it doesn't work *hairpull*
    //I might have to use some sort of instansiate() and immediately disable 
    /*public Checkpoint(Vector3 position)
    {
        gameObject.transform.position = position;
        //GetComponent<SpriteRenderer>().enabled = false;
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().sprite = activeSprite;
            playerStatistics.lastCheckpoint(this);
        }
    }

    public void becomeInactive()
    {
        this.GetComponent<SpriteRenderer>().sprite = inactiveSprite;
    }
    // Use this for initialization
    void Start () {
        playerStatistics = GameObject.Find(GameConst.PLAYER_OBJECT_NAME).GetComponent<PlayerStatistics>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
