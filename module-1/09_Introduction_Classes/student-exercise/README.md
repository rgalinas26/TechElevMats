# Introduction to Classes

The purpose of this exercise is to provide you the opportunity to define and use classes. The names of the classes, methods, and properties are specified in the Evaluation Criteria & Functional Requirements section.

## Learning Objectives

After completing this exercise, students will understand:

* How to create classes.
* How to create properties.
* How to override a default constructor.
* How to manage the state of an object.
* How to limit access to properties through the use of [access modifiers][dot-net-access-modifiers].

## Evaluation Criteria & Functional Requirements

* The project must not have any build errors.
* Unit tests pass as expected.
* Appropriate variable names and data types are being used.
* Code is presented in a clean, organized format.
* If a property does not have set marked, then it should be considered `private set`.
* The code meets the specifications defined below.

### Difficulty - Easy

#### **Product**

**Class Properties**

| Property Name  | Data Type | Get | Set | Description                                  |
| -------------- | --------- | --- | --- | -------------------------------------------- |
| Name           | string    | X   | X   | Holds the name of the product.               |
| Price          | decimal   | X   | X   | Holds the price of the product.              |
| WeightInOunces | double    | X   | X   | Holds the weight (in ounces) of the product. |

#### **Company**

**Class Properties**

| Property Name     | Data Type | Get | Set | Description                    |
| ----------------- | --------- | --- | --- | ------------------------------ |
| Name              | string    | X   |     | Holds the name of the company. |
| NumberOfEmployees | int       | X   | X   | Holds the number of employees. |
| Revenue           | decimal   | X   | X   | Holds the company revenue.     |
| Expenses          | decimal   | X   | X   | Holds the company expenses.    |

**Constructors**

| Signature                    | Description                                                                     |
| ---------------------------- | ------------------------------------------------------------------------------- |
| Company(string startingName) | Starting name of the company. This should set the value of the `Name` property. |

**Methods**

| Method Name      | Return Type | Description                                                                                                                     |
| ---------------- | ----------- | ------------------------------------------------------------------------------------------------------------------------------- |
| GetCompanySize() | string      | A company is "small" if less than 50 employees, "medium" if between 50 and 250 employees, "large" if greater than 250 employees |
| GetProfit()      | decimal     | Calculated by subtracting expenses from revenue.                                                                                |

#### **Person**

**Class Properties**

| Property Name | Data Type | Get | Set | Description                         |
| ------------- | --------- | --- | --- | ----------------------------------- |
| FirstName     | string    | X   | X   | Holds the first name of the person. |
| LastName      | string    | X   | X   | Holds the last name of the person.  |
| Age           | int       | X   | X   | Holds the age of the person.        |

**Methods**

| Method Name   | Return Type | Description                                       |
| ------------- | ----------- | ------------------------------------------------- |
| GetFullName() | string      | Returns the First Name + Last Name of the Person. |
| IsAdult()     | bool        | Returns `true` if the person is 18 or older.      |

### Difficulty - Medium

#### **Dog**

**Class Properties**

| Property Name | Data Type | Get | Set | Description                                                                        |
| ------------- | --------- | --- | --- | ---------------------------------------------------------------------------------- |
| IsSleeping    | bool      | X   |     | `TRUE` if the dog is asleep. `FALSE` if not. **All new dogs are awake by default** |

**Constructors**

| Signature | Description                                                               |
| --------- | ------------------------------------------------------------------------- |
| Dog()     | Dog constructor takes no arguments. **All new dogs are awake by default** |

**Methods**

| Method Name | Return Type | Description                                                                       |
| ----------- | ----------- | --------------------------------------------------------------------------------- |
| MakeSound() | string      | Returns `"Zzzzz..."` if the dog is asleep. Returns `"woof!"` if the dog is awake. |
| Sleep()     | void        | Sets `IsSleeping` to `true`.                                                      |
| WakeUp()    | void        | Sets `IsSleeping` to `false`.                                                     |

#### **Shopping Cart**

**Class Properties**

| Property Name      | Data Type | Get | Set | Description                                                                              |
| ------------------ | --------- | --- | --- | ---------------------------------------------------------------------------------------- |
| TotalNumberOfItems | int       | X   |     | The number of items in the shopping cart. **All shopping carts have 0 items by default** |
| TotalAmountOwed    | decimal   | X   |     | The total for the shopping cart. **All shopping carts have 0.0 owed by default**         |

**Methods**

| Method Name                                       | Return Type | Description                                                                                      |
| ------------------------------------------------- | ----------- | ------------------------------------------------------------------------------------------------ |
| GetAveragePricePerItem()                          | decimal     | Returns the `TotalAmountOwed / TotalNumberOfItems`.                                              |
| AddItems(int numberOfItems, decimal pricePerItem) | void        | Updates `TotalNumberOfItems` and increases `TotalAmountOwed` by `(pricePerItem * numberOfItems)` |
| Empty()                                           | void        | Resets `TotalNumberOfItems` and `TotalAmountOwed` to 0.                                          |

### Difficulty - Difficult

#### **Calculator**

**Class Properties**

| Property Name | Data Type | Get | Set | Description                               |
| ------------- | --------- | --- | --- | ----------------------------------------- |
| Result        | int       | X   |     | Holds the current value of the calculator |

**Constructors**

| Signature                      | Description                                                                            |
| ------------------------------ | -------------------------------------------------------------------------------------- |
| Calculator(int startingResult) | Starting value of the calculator. Initialize `Result` to the value of `startingResult` |

**Methods**

| Method Name              | Return Type | Description                                                                                                                     |
| ------------------------ | ----------- | ------------------------------------------------------------------------------------------------------------------------------- |
| Add(int addend)          | int         | Adds `addend` to `Result` and returns the current value of `Result`.                                                            |
| Subtract(int subtrahend) | int         | Subtracts `subtrahend` from the current value of `Result` and returns the current value of `Result`.                            |
| Multiply(int multiplier) | int         | Multiplies current result by `multiplier` and returns the current value of `Result`.                                            |
| Power(int exponent)      | int         | Raises `Result` to power of `exponent`. Negative exponents should use the absolute value. Returns the current value of `Result` |
| Reset()                  | void        | Resets `Result` to 0.                                                                                                           |
## Getting Started

* Open the introduction-to-classes-exercise.sln solution in Visual Studio.
* Click on the **Test -> Run -> All Tests** Menu
* Click on the **Test Explorer** tab to see the results of your tests and which passed / failed.
* Provide enough code to get a test passing.
* Repeat until all tests are passing.

## Tips and Tricks

* **Note, If you find yourself stuck on a problem for longer than fifteen minutes, move onto the next, and try again later.**
* In this exercise, you will be provided with a series of specification for classes you will be responsible for creating. Each class comes with its own challenge and nuance, and you may find that some of these classes are more challenging than others to implement.
* In this exercise, you will be creating the classes specified in the requirements section of this document. The unit tests you run will verify if you have defined the classes correctly. As you work on creating the classes, be sure to run the tests, and then provide enough code to pass the test. For instance, if you are working on the Product class, provide enough code to get one of the Product tests passing. By focusing on getting a single test to pass at a time, you will save yourself a lot of time, as this forces you to only focus on what is important for the test you are currently working on. This is commonly referred to as **[Test Driven Development][introduction-to-test-driven-development]**, or **TDD**.
* What happens if you don't define any [constructors][dot-net-constructors] in a class? Does your code still work as expected? Why or why not?
* When you provide an explicit constructor with arguments in a class, what happens to the default constructor (a constructor with no arguments)?
* While making the tests pass and adhering to the specification is all that is technically required for this exercise, you may also choose to gain additional practice by writing code in the Program.cs files for each of the projects. For example, you could instantiate an instance of your Calculator class in the CalculatorExercise/Program.cs file, and execute methods, printing out the results to the console.
* Be mindful of your [access modifiers][dot-net-access-modifiers].

---

[dot-net-access-modifiers]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers
[dot-net-constructors]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
[introduction-to-test-driven-development]: http://agiledata.org/essays/tdd.html