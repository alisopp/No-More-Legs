using NoMoreLegs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovableObject _movableObject;
    private PlayerHookController _playerHookController;
    private start_movement _startMovement;

    private void Awake()
    {
        _playerHookController = GetComponent<PlayerHookController>();
        _startMovement = GetComponent<start_movement>();
        _playerHookController.enabled = false;
        _startMovement.enabled = true;
    }


    public void LoseLegs()
    {
        _playerHookController.enabled = true;
        _startMovement.enabled = false;
    }
}
