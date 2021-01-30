using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragment : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (!collision.CompareTag("Player"))
            return;
        var projectileLauncher = collision.GetComponent<ProjectileLauncher>();
        if(projectileLauncher!=null)
        {
            projectileLauncher.enlightened = true;
            GameManager.Instance.GotMemoryFragment();
            Destroy(gameObject);
        }
    }
}
