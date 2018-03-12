
# Global variables
[string] $slnPath = "../RecruitJr.sln";
$testPaths = @("../RecruitJr.DAL.Postgresql.Tests/RecruitJr.DAL.Postgresql.Tests.csproj")

Function Main {
    BuildSolution
    RunTests
}

# Output functions. Move to separate script and include
Function Info {
    Param([string] $message)
    Write-Host $message -ForegroundColor DarkGreen
}

Function Error {
    Param([string] $message)
    Write-Host $message -ForegroundColor Red
}

Function Warning {
    Param([string] $message)
    Write-Host $message -ForegroundColor Yellow
}

# Build functions

Function BuildSolution {
    $result = (dotnet build $slnPath) | Out-String 
    if ($result.Contains("Build succeeded")) {
        Info "Build passed"
    } else {
        Error "Build failed:"
        Write-Host $result
        Exit
    }
}

Function RunTests {
    foreach($testPath in $testPaths)
    {
        $result = (dotnet test $testPath) | Out-String
        if ($result.Contains("Test Run Successful")) {
            Info "Tests passed"
        } else {
            Error "Tests failed:"
            Write-Host $result
            Exit
        }
    }
}

Main