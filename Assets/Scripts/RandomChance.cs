using UnityEngine;

public class RandomChance : MonoBehaviour
{
    public bool Random(float chance)
    {
        float rand = UnityEngine.Random.Range(0, 100);
        Debug.Log(chance + "����");
        Debug.Log(rand + "������");

        return rand <= chance;
    }
}