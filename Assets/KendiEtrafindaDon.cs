using UnityEngine;

public class KendiEtrafindaDon : MonoBehaviour
{
    public float donmeHizi = 50f; // Hızı Unity içinden değiştirebilmen için dışarı açtık

    void Update()
    {
        transform.Rotate(0, donmeHizi * Time.deltaTime, 0);
    }
}