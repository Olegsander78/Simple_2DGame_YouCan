using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public bool FinalLeval;
    public string NextSceneName;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FinalLeval)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(NextSceneName);
            }
        }
    }
}
