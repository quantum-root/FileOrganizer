# 📁 Modern File Organizer

<p align="center">
  <b>A sleek, lightning-fast desktop application built with C# and WPF to automatically organize and categorize messy folders with a single click.</b>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/WPF-%235C2D91.svg?style=for-the-badge&logo=.net&logoColor=white" alt="WPF">
  <img src="https://img.shields.io/badge/.NET-8.0-%23512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8.0">
  <img src="https://img.shields.io/badge/License-MIT-blue.svg?style=for-the-badge" alt="MIT License">
</p>

---

## ✨ Features

* **🎨 Modern Dark UI:** Designed with a sleek dark aesthetic for a comfortable and smooth user experience.
* **🧠 Smart Categorization:** Instantly detects file extensions and routes them to their designated folders.
* **📊 Live Activity Console:** Built-in real-time logging panel tracking operations with precise timestamps.
* **⚡ Safe & Lightweight:** Zero bloat, highly efficient processing using native .NET libraries.

---

## 📂 Supported Categories

| Category | File Extensions |
| :--- | :--- |
| **Images** | `.jpg`, `.jpeg`, `.png`, `.gif` |
| **Documents** | `.pdf`, `.docx`, `.txt`, `.xlsx` |
| **Videos** | `.mp4`, `.mkv`, `.avi` |
| **Music** | `.mp3`, `.wav` |
| **Archives** | `.zip`, `.rar`, `.7z` |
| **Applications** | `.exe`, `.msi` |
| **Others** | *Any other extension* |

---

## 🛠️ Built With

* **Language:** C#
* **Framework:** WPF (.NET 8.0)
* **Core Libraries:** `System.IO`, `System.Windows.Forms`

---

## 💻 How to Use

1. **Launch** the application.
2. Click **"Select Folder"** to choose the target directory you want to clean.
3. Click **"Organize Files"** to trigger the sorting mechanism.
4. **Monitor** the live log console at the bottom for instant feedback on moved files.

---
## ⚙️ Getting Started

To run this project locally, make sure you have **.NET 8.0 SDK** or later installed on your machine.

### Prerequisites
* [Download .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Visual Studio 2022 (or any preferred C# IDE)

### Installation & Running

```bash
# 1. Clone the repository
git clone [https://github.com/quantum-root/FileOrganizer.git](https://github.com/quantum-root/FileOrganizer.git)

# 2. Navigate into the project directory
cd FileOrganizer

# 3. Build the solution (or open FileOrganizer.sln in Visual Studio)
dotnet build

# 4. Run the application via terminal (or press F5 in Visual Studio)
dotnet run --project FileOrganizer/FileOrganizer.csproj
```
---

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 🏛️ Project Structure

```text
FileOrganizer/
│
├── FileOrganizer.sln           # Solution file
└── FileOrganizer/              # Main project folder
    ├── App.xaml / .cs          # Application startup & configuration
    ├── MainWindow.xaml / .cs   # User interface & core logic
    ├── AssemblyInfo.cs         # Assembly attributes
    └── FileOrganizer.csproj    # Project settings (.NET 8.0)
