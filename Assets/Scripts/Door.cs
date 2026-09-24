using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (gameObject.tag == "Casino" && Player.Instance.coins > 0)
        {
            GameManager.Instance.LoadGambleRoomScene();
        }
        else if (gameObject.tag == "Level1")
        {
            GameManager.Instance.LoadScene(gameObject.tag);
        }
    }
}
