using UnityEngine;
using UnityEngine.UI;

public class GaleriKontrol : MonoBehaviour
{
    public Image fotoCercevesi;
    public Sprite[] fotograflar;
    private int mevcutSira = 0;

    void Start()
    {
        if (fotograflar.Length > 0)
            fotoCercevesi.sprite = fotograflar[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            IleriGit();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GeriGit();
        }
    }

    public void IleriGit()
    {
        mevcutSira++;
        if (mevcutSira >= fotograflar.Length)
            mevcutSira = 0;
        fotoCercevesi.sprite = fotograflar[mevcutSira];
    }

    public void GeriGit()
    {
        mevcutSira--;
        if (mevcutSira < 0)
            mevcutSira = fotograflar.Length - 1;
        fotoCercevesi.sprite = fotograflar[mevcutSira];
    }
}