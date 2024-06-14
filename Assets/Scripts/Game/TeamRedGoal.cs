using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamRedGoal : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            FindObjectOfType<Audio_Manager>().Play("Goal");
            GameManager.instance.SpawnAtTeamBlue();
            Destroy(collision.gameObject);
        }
    }

}
