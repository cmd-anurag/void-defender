using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField]private AudioSource EnemyDeathSound;
    private void OnEnable() {
        EnemyScript.OnEnemyDeath += PlayEnemyDeathSound;
    }
    private void OnDisable() {
        EnemyScript.OnEnemyDeath -= PlayEnemyDeathSound;
    }
    private void PlayEnemyDeathSound(int s, Transform position) {
        EnemyDeathSound.Play();
    }
}
