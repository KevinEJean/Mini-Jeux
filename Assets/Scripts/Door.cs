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
            return;
        }
        else if (gameObject.tag == "Level1")
        {
            GameManager.Instance.LoadScene(gameObject.tag);
            return;
        }

        Debug.Log("Boss : 'Job's not done! Get back in there!' (Complete the level to unlock this door)");
    }
}
