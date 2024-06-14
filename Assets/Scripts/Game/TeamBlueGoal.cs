using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBlueGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            FindObjectOfType<Audio_Manager>().Play("Goal");
            GameManager.instance.SpawnAtTeamRed();
            Destroy(collision.gameObject);
        }
    }
}
