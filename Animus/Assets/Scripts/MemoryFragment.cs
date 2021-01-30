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
            projectileLauncher.Enlight();
            GameManager.Instance.GotMemoryFragment();
            AudioManager.Instance.PlaySoundEffect("Collect");
            Destroy(gameObject);
        }
    }
}
