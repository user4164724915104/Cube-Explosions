using UnityEngine;

public class RandomChance : MonoBehaviour
{
    public float chance;

    public bool Random()
    {
        float rand = UnityEngine.Random.Range(0, 100);
        Debug.Log(chance + "����");
        Debug.Log(rand + "������");

        if (rand <= chance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}