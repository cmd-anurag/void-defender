using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField]private AudioSource EnemyDeathSound;
    [SerializeField]private AudioSource SpaceShipDeathSound;

    private void OnEnable() {
        EnemyScript.OnEnemyDeath += PlayEnemyDeathSound;
        SpaceshipControllerScript.OnSpaceShipDeath += PlaySpaceShipDeathSound;
    }

    private void OnDisable() {
        EnemyScript.OnEnemyDeath -= PlayEnemyDeathSound;
        SpaceshipControllerScript.OnSpaceShipDeath -= PlaySpaceShipDeathSound;
    }


    private void PlayEnemyDeathSound(int s, Transform position) {
        EnemyDeathSound.Play();
    }

    private void PlaySpaceShipDeathSound(Transform position) {
        SpaceShipDeathSound.Play();
    }
}
