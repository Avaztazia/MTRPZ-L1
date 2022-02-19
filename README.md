# Quadratic Equations Solver
This is a quadratic equations solver with a console interface.

Now solver supportes 2 mode:

- Interactive (coefficients taken from console input)
- Non interactive (coefficients taken from file)
 
## Interactive
![image](https://user-images.githubusercontent.com/71588076/154800693-559b7857-dec4-4af0-8b0f-b7c91920d1cb.png)

## Non interactive
![image](https://user-images.githubusercontent.com/71588076/154800720-75ce47e5-9e86-452f-8412-3afc5811aba5.png)
### 1.txt content:
```
14 21 3
```

# How to build

## Build from sources
1. Download and install [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Clone the repo with a project
3. Start your's terminal at the folder that contains `EquationSolver.ConsoleUI.csproj` file
4. Execute .NET CLI command `dotnet build` and then `dotnet run`

## Use portable version that is already build and usage-ready
1. Go to the releases page
2. Download the last stable realease
3. Execute `EquationSolver.ConsoleUI.exe`

# Non Interactive mode
To use non interact mode specify a path to a `.txt` ot `.text` file that will contains a row of three numbers.

### Example
```
14 21 3
```

### Revert commit hash: [a0a1176](https://github.com/Avaztazia/MTRPZ-L1/commit/a0a11767ae0c49f5b324a5b6f266a9deb361ddd0)
