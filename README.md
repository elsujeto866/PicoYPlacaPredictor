# Pico y Placa Predictor - WPF Application

This is a desktop application built with **C# and WPF**, designed to predict whether a vehicle can circulate in **Quito, Ecuador**, based on the **Pico y Placa** traffic restriction policy.

---

## 📊 Features

* Validation based on:

  * Last digit of the license plate
  * Date and time input
  * Weekend and holiday exceptions
* Decoupled logic using SOLID principles and object-oriented programming
* Clean and intuitive graphical interface
* Real-time input validation with helpful error messages
* Unit and integration testing included

---

## 🌐 Technologies and Tools

* .NET 8.0 (Windows)
* WPF (XAML UI)
* NUnit (unit testing)
* C# with OOP (interfaces, inheritance, encapsulation)
* Git for version control

---

## 🔧 Installation & Running the App

1. Clone the repository:

```bash
git clone https://github.com/your-username/pico-y-placa-predictor.git
```

2. Open the solution in Visual Studio 2022 or newer.

3. Ensure the startup project is `PicoYPlacaPredictor` and the target framework is `.NET 8.0-windows`.

4. Build and run the application.

---

## 📄 Input Format

* **License Plate**: Three uppercase letters + dash + 3 or 4 digits (e.g., `ABC-1234`)
* **Date**: Picked via `DatePicker` (`yyyy-MM-dd` format)
* **Time**: Typed manually in `HH:mm` format (e.g., `08:30`)

---

## 🤖 Project Structure

```
├── Business
│   ├── Interfaces
│   ├── Rules
│   └── Validators
├── Entities
├── PicoYPlacaPredictor (WPF UI)
├── PicoYPlacaPredictor.Tests
│   ├── Validators
│   ├── Rules
│   └── Integration
```

---

## 🛠️ Validation Logic

1. **Exceptions** are checked first (weekend, holiday):

   * If any apply, the vehicle **can circulate**

2. If not, the **Pico y Placa rules** are checked:

   * If the vehicle's last digit matches the restricted day **and** the time falls within the restricted hours → **cannot circulate**

---

## ✅ Test Coverage

* Individual validators (time, digit, exceptions)
* Combined rule validator
* Integration tests for the full circulation validator

To run tests:

```bash
dotnet test
```

---

## 🚀 Potential Enhancements

* Load holidays from external JSON or API
* Add query history to the UI
* Support for light/dark themes

---

## 👤 Author

Developed by **Dorian Maza** as a technical exercise for Stack Builders.

---

## 📅 Status

Feature-complete and fully functional ✔

---

## 🔗 License

This project is for personal and technical evaluation use. No commercial license is applied by default.
