using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator _playerAnimator;

    void OnEnable() {
        GameManager.Instance.OnWinGame += PlayWinGameAnimation;
        GameManager.Instance.OnLoseGame += PlayLoseGameAnimation;
    }

    void OnDisable() {
        GameManager.Instance.OnWinGame -= PlayWinGameAnimation;
        GameManager.Instance.OnLoseGame -= PlayLoseGameAnimation;
    }

    private void Awake() {
        _playerAnimator = GetComponent<Animator>();
    }


    void PlayWinGameAnimation() {
        Vector3 lookRotation = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(lookRotation);
        _playerAnimator.SetBool("hasWon", true);
    }

    void PlayLoseGameAnimation() {
        Vector3 lookRotation = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(lookRotation);
        _playerAnimator.SetBool("hasLost", true);
    }
}