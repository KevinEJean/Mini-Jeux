using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (gameObject.tag == "Casino")
        {
            GameManager.Instance.LoadGambleRoomScene();
            return;
        } else if (GameManager.Instance.levelCompleted) 
        {
            GameManager.Instance.LoadScene(gameObject.tag);
            return;
        }
    }
}
