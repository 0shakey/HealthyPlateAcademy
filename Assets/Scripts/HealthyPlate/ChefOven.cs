using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefOven : CookingTool
{
    public override string cookingLocation { get; set; } = "OvenLocation";

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    public override IEnumerator CookingTime(Collider other)
    {
        Ingredient ingredientSetter = other.transform.GetComponentInParent<Ingredient>();
        timeUntilCooked = ingredientSetter.ingredientSO.timeUntilOvenCooked;
        nextFood = ingredientSetter.ingredientSO.ovenCookedPrefab;
        destroyAfterCooked = ingredientSetter.ingredientSO.destroyAfterOvenCooked;

        return base.CookingTime(other);
    }

    public override IEnumerator Overcooked(Ingredient cookedFood)
    {
        return base.Overcooked(cookedFood);
    }
}
