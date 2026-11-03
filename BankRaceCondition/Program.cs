using BankRaceCondition.Models;
using BankRaceCondition.Services;

const int workers = 10;
const int operations = 1000;
const decimal amount = 10;
decimal expected = workers * operations * amount;

var simulator = new BankSimulator();

// ЭТАП 1
Console.WriteLine("ЭТАП 1");
var accountUnsafe = new BankAccount();

Console.WriteLine($"Начальный баланс: {accountUnsafe.Balance}");
Console.WriteLine($"Количество задач: {workers}");
Console.WriteLine($"Операций на задачу: {operations}");
Console.WriteLine($"Сумма пополнения: {amount}");
Console.WriteLine($"Ожидаемый баланс: {expected}");

await simulator.RunUnsafeAsync(accountUnsafe, workers, operations, amount);

Console.WriteLine();
Console.WriteLine($"Фактический баланс: {accountUnsafe.Balance}");
Console.WriteLine($"Разница (потерянные деньги): {expected - accountUnsafe.Balance}");


Console.WriteLine("\n-------------------------------------------------\n");


// ЭТАП 2
Console.WriteLine("ЭТАП 2");
var accountSafe = new BankAccount();

Console.WriteLine($"Начальный баланс: {accountSafe.Balance}");
Console.WriteLine($"Ожидаемый баланс: {expected}");

await simulator.RunSafeAsync(accountSafe, workers, operations, amount);

Console.WriteLine();
Console.WriteLine($"Фактический баланс: {accountSafe.Balance}");
Console.WriteLine($"Разница: {expected - accountSafe.Balance}");