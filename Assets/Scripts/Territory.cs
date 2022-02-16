using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Territory : MonoBehaviour
{
    public enum TerritoryProduct {SOAP, ENTERTAINMENT, CLASSIC, SPORTS}
    
    public TerritoryProduct territoryProduct;
    public string location;

    public string[] places;
    public string[] companies;
    public string territoryName;
    public string territoryInitials;

    private void Awake()
    {
        int i = Random.Range(0, 4);
        TerritoryProduct[] productRandomiser = { TerritoryProduct.SOAP, TerritoryProduct.ENTERTAINMENT, TerritoryProduct.CLASSIC, TerritoryProduct.SPORTS };
        territoryProduct = productRandomiser[i];
    }
}
