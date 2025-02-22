using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct IngredientHolder 
{
    public IngredientSO ingredient;
    public int quantity;
    public float unitMeasurement;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Cooking/Recipe")]
public class RecipeSO : IngredientSO
{
    [Header("Recipe")]
    public float recipeTime = 60.0f;
    public GameObject completedRecipe;
    public List<IngredientHolder> ingredientHolders;
}