using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ChefPan : NetworkBehaviour
{
    // Dictionary to store coroutines for each ingredient
    private Dictionary<Ingredient, Coroutine> ingredientCoroutines = new Dictionary<Ingredient, Coroutine>();

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            if (other.transform.root.gameObject.GetComponent<Ingredient>().ingredientSO.searedPrefab == null)
            {
                return;
            }

            // Get the ingredient object
            Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

            // Start the coroutine for this specific ingredient if it's not already being seared
            if (!ingredientCoroutines.ContainsKey(ingredient))
            {
                Coroutine searingCoroutine = StartCoroutine(SearTime(other));
                ingredientCoroutines.Add(ingredient, searingCoroutine);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Ingredient")
        {
            // Get the ingredient object
            Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

            // If the food leaves the pan, stop its specific coroutine
            if (ingredientCoroutines.ContainsKey(ingredient))
            {
                StopCoroutine(ingredientCoroutines[ingredient]);
                ingredientCoroutines.Remove(ingredient); // Remove the coroutine from the dictionary
            }
        }
    }

    public IEnumerator SearTime(Collider other)
    {
        Ingredient ingredient = other.transform.GetComponentInParent<Ingredient>();

        yield return new WaitForSeconds(ingredient.GetComponent<Ingredient>().ingredientSO.timeUntilSeared);

        // Only proceed if the ingredient is still in the dictionary (i.e., it hasn't left the pan)
        if (ingredientCoroutines.ContainsKey(ingredient))
        {
            Runner.Spawn(ingredient.GetComponent<Ingredient>().ingredientSO.searedPrefab, ingredient.transform.position, ingredient.transform.rotation);

            if (ingredient.GetComponent<Ingredient>().ingredientSO.destroyAfterSeared)
            {
                Runner.Despawn(ingredient.GetComponent<NetworkObject>());
            }

            // Remove the ingredient from the dictionary once the searing is complete
            ingredientCoroutines.Remove(ingredient);
        }
    }
}
