using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator _playerAnimator;


    void OnEnable() {
        Inventory playerInventory = GetComponent<Inventory>();
        playerInventory.OnItemAmountChange += SetItemAmountParameter;

        GameManager.Instance.OnWinGame += PlayWinGameAnimation;
        GameManager.Instance.OnLoseGame += PlayLoseGameAnimation;
        GameManager.Instance.OnStartGame += PlayMovingAnimation;
    }

    void OnDisable() {
        Inventory playerInventory = GetComponent<Inventory>();
        playerInventory.OnItemAmountChange -= SetItemAmountParameter;

        GameManager.Instance.OnWinGame -= PlayWinGameAnimation;
        GameManager.Instance.OnLoseGame -= PlayLoseGameAnimation;
        GameManager.Instance.OnStartGame -= PlayMovingAnimation;
    }

    void Awake() {
        _playerAnimator = GetComponent<Animator>();
    }


    public void PlayPointCollectAnimation() {
        _playerAnimator.SetTrigger("pointCollected");
    }

    void SetItemAmountParameter(int itemAmount) {
        _playerAnimator.SetInteger("itemAmount", itemAmount);
    }

    void PlayMovingAnimation() {
        _playerAnimator.SetBool("isMoving", true);
    }

    void PlayWinGameAnimation(int score) {
        Vector3 lookRotation = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(lookRotation);
        _playerAnimator.SetBool("hasWon", true);
    }

    void PlayLoseGameAnimation(int score) {
        Vector3 lookRotation = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(lookRotation);
        _playerAnimator.SetBool("hasLost", true);
    }
}