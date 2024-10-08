using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for using UI components like InputField

// Main StoreSimulation class, attached to a GameObject in Unity
public class StoreSimulation : MonoBehaviour
{
    public InputField customerFrequencyInput;
    public InputField averageCheckoutInput;
    public InputField overheadInput;
    public Text profitText;

    private Store store;

    // Called once at the start of the scene
    void Start()
    {
        // Initialize the store with an overhead cost from the input
        store = new Store(float.Parse(overheadInput.text));
    }

    // Method to add a customer
    public void AddCustomer()
    {
        // Get customer input values from UI fields
        float frequency = float.Parse(customerFrequencyInput.text);
        float averageCheckout = float.Parse(averageCheckoutInput.text);

        // Create and add a new customer to the store
        Customer newCustomer = new Customer("Regular", averageCheckout, frequency);
        store.customers.Add(newCustomer);
    }

    // Method to calculate and display profit
    public void CalculateProfit()
    {
        // Calculate the daily profit
        float profit = store.CalculateDailyRevenue();

        // Update the UI with the calculated profit
        profitText.text = "Daily Profit: $" + profit.ToString("F2");
    }
}

// Customer class definition
public class Customer
{
    public string customerType;
    public float averageCheckoutTotal;
    public float frequency;

    // Constructor for Customer
    public Customer(string type, float total, float freq)
    {
        customerType = type;
        averageCheckoutTotal = total;
        frequency = freq;
    }
}

// Store class definition
public class Store
{
    public float dailyOverhead;
    public List<Customer> customers;

    // Constructor for Store
    public Store(float overhead)
    {
        dailyOverhead = overhead;
        customers = new List<Customer>();
    }

    // Method to calculate total daily revenue
    public float CalculateDailyRevenue()
    {
        float revenue = 0;

        // Calculate total revenue from all customers
        foreach (Customer customer in customers)
        {
            revenue += customer.averageCheckoutTotal * customer.frequency;
        }

        // Subtract overhead to get the profit
        return revenue - dailyOverhead;
    }
}
