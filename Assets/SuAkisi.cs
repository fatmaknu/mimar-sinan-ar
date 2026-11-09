using UnityEngine;

public class SuAkisi : MonoBehaviour
{
    public float dalgaBoyu = 2f;          // Dalganın genişliği (sık veya geniş dalgalar)
    public float dalgaHizi = 1.5f;        // Dalgalanma hızı
    public float dalgaYuksekligi = 0.03f; // Dalganın yukarı ne kadar kabaracağı
    public float akintiHizi = 0.2f;       // Suyun ileriye doğru akma hızı

    private Mesh mesh;
    private Vector3[] anaKoseler;
    private Renderer render;

    void Start()
    {
        // Plane objesinin üzerindeki ağ (mesh) yapısını al
        mesh = GetComponent<MeshFilter>().mesh;
        anaKoseler = mesh.vertices;
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        // 1. Doku kaydırması ile suyu ileriye doğru akıt
        render.material.mainTextureOffset += new Vector2(0, akintiHizi * Time.deltaTime);

        // 2. Yüzeydeki noktaları bükerek GERÇEK bir dalga oluştur
        Vector3[] yeniKoseler = new Vector3[anaKoseler.Length];
        for (int i = 0; i < anaKoseler.Length; i++)
        {
            Vector3 kose = anaKoseler[i];

            // X ve Z eksenlerindeki noktalara sinüs matematiği ile dalga veriyoruz
            kose.y = anaKoseler[i].y + Mathf.Sin(Time.time * dalgaHizi + anaKoseler[i].x * dalgaBoyu + anaKoseler[i].z * dalgaBoyu) * dalgaYuksekligi;
            yeniKoseler[i] = kose;
        }

        mesh.vertices = yeniKoseler;
        mesh.RecalculateNormals(); // Suyun üzerindeki parlamaların dalgaya göre değişmesi için
    }
}