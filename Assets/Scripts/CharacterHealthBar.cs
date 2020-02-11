using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHealthBar : MonoBehaviour
{
    public Slider healthBar = null;
    Health charHealth;
    // Start is called before the first frame update
    void Start()
    {
        charHealth = GetComponent<Health>();
        healthBar.value = ConvertHealthtoPercentage();
    }

    private float ConvertHealthtoPercentage()
    {
        return charHealth.GetHealthPoints() / charHealth.ReturnMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = ConvertHealthtoPercentage();
        if (charHealth.GetDeathState())
        {
            Destroy(healthBar);
        }
    }
}
