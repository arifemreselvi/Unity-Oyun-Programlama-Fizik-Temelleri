using UnityEngine;

public class BilardoIsteka : MonoBehaviour
{
    public Rigidbody beyazTop;
    public float donmeHizi = 20f;
    public float yaklasmaHizi = 20f;
    private float vurmaGucu = 0f;
    private bool vurulacakMi = false;
    private float cekilmeMiktari = 0f;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void Update()
    {
        float donme = Input.GetAxis("Horizontal");
        transform.RotateAround(beyazTop.position, Vector3.up, donme * donmeHizi * Time.deltaTime);

        transform.LookAt(beyazTop.position);
        transform.Rotate(90, 0, 0);

        float yaklasma = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * yaklasma * yaklasmaHizi * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            if (vurmaGucu < 100f)
            {
                vurmaGucu += 50f * Time.deltaTime;
                float cekilme = 2f * Time.deltaTime;
                transform.Translate(Vector3.down * cekilme);
                cekilmeMiktari += cekilme;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            vurulacakMi = true;
            transform.Translate(Vector3.up * (cekilmeMiktari + 1.2f));
            cekilmeMiktari = 0f;
        }
    }

    void FixedUpdate()
    {
        if (vurulacakMi)
        {
            float mesafe = Vector3.Distance(transform.position, beyazTop.position);

            if (mesafe < 10f)
            {
                Vector3 vurusYonu = (beyazTop.position - transform.position).normalized;
                vurusYonu.y = 0;
                beyazTop.AddForce(vurusYonu * vurmaGucu, ForceMode.Impulse);
            }

            vurmaGucu = 0f;
            vurulacakMi = false;
        }
    }
}