using SharedKernel.Domain.Primitives;

namespace Expenses.Domain.Expenses;

public class ExpenseCategory : Enumeration
{
    public string DisplayName { get; }

    private ExpenseCategory(string name, string displayName) : base(name)
    {
        DisplayName = displayName;
    }

    public static readonly ExpenseCategory FoodAndGroceries = new("FoodAndGroceries", "Food and Groceries");
    public static readonly ExpenseCategory DiningOut = new("DiningOut", "Dining Out");
    public static readonly ExpenseCategory Entertainment = new("Entertainment", "Entertainment");
    public static readonly ExpenseCategory Utilities = new("Utilities", "Utilities");
    public static readonly ExpenseCategory RentOrMortgage = new("RentOrMortgage", "Rent or Mortgage");
    public static readonly ExpenseCategory Transportation = new("Transportation", "Transportation");
    public static readonly ExpenseCategory Fuel = new("Fuel", "Fuel");
    public static readonly ExpenseCategory Insurance = new("Insurance", "Insurance");
    public static readonly ExpenseCategory MedicalAndHealthcare = new("MedicalAndHealthcare", "Medical and Healthcare");
    public static readonly ExpenseCategory Education = new("Education", "Education");
    public static readonly ExpenseCategory Travel = new("Travel", "Travel");
    public static readonly ExpenseCategory Clothing = new("Clothing", "Clothing");
    public static readonly ExpenseCategory PersonalCare = new("PersonalCare", "Personal Care");
    public static readonly ExpenseCategory Childcare = new("Childcare", "Childcare");
    public static readonly ExpenseCategory GiftsAndDonations = new("GiftsAndDonations", "Gifts and Donations");
    public static readonly ExpenseCategory SavingsAndInvestments = new("SavingsAndInvestments", "Savings and Investments");
    public static readonly ExpenseCategory Taxes = new("Taxes", "Taxes");
    public static readonly ExpenseCategory LoanRepayment = new("LoanRepayment", "Loan Repayment");
    public static readonly ExpenseCategory SubscriptionServices = new("SubscriptionServices", "Subscription Services");
    public static readonly ExpenseCategory HomeMaintenance = new("HomeMaintenance", "Home Maintenance");
    public static readonly ExpenseCategory ElectronicsAndGadgets = new("ElectronicsAndGadgets", "Electronics and Gadgets");
    public static readonly ExpenseCategory HobbiesAndLeisure = new("HobbiesAndLeisure", "Hobbies and Leisure");
    public static readonly ExpenseCategory Pets = new("Pets", "Pets");
    public static readonly ExpenseCategory Miscellaneous = new("Miscellaneous", "Miscellaneous");

    //TODO: Refactor this method to use reflection or the base class method that is built for listing all possible values of a specific Enumeration type.
    public static IEnumerable<ExpenseCategory> List() =>
        new[] {
            FoodAndGroceries,
            DiningOut,
            Entertainment,
            Utilities,
            RentOrMortgage,
            Transportation,
            Fuel,
            Insurance,
            MedicalAndHealthcare,
            Education,
            Travel,
            Clothing,
            PersonalCare,
            Childcare,
            GiftsAndDonations,
            SavingsAndInvestments,
            Taxes,
            LoanRepayment,
            SubscriptionServices,
            HomeMaintenance,
            ElectronicsAndGadgets,
            HobbiesAndLeisure,
            Pets,
            Miscellaneous
        };

    public static ExpenseCategory FromName(string name)
    {
        return List().SingleOrDefault(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase))
               ?? throw new ArgumentException($"The specified name '{name}' is not a valid {nameof(ExpenseCategory)} name.", nameof(name));
    }
}