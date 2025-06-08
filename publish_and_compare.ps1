# Define project names
$projects = @("MessagePackCSharp", "Nerdbank")

Write-Host "============================"
Write-Host "=== Cleaning old outputs ==="
Write-Host "============================"

foreach ($project in $projects) {
    Write-Host "Cleaning: $project"

    Remove-Item "$project/bin" -Recurse -Force -ErrorAction SilentlyContinue
    Remove-Item "$project/obj" -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host "============================="
Write-Host "=== Building the projects ==="
Write-Host "============================="

foreach ($project in $projects) {
    Write-Host "=== Publishing $project ==="

    dotnet publish $project
}

Write-Host "============================"
Write-Host "=== File size of outputs ==="
Write-Host "============================"

foreach ($project in $projects) {
    Write-Host "=== $project Output ==="
    
    $outputPath = Join-Path -Path $project -ChildPath "bin\Release\net8.0\win-x64\publish"
    $exeFile = Join-Path $outputPath "$project.exe"
    $pdbFile = Join-Path $outputPath "$project.pdb"

    if (Test-Path $exeFile) {
        $exeSizeBytes = (Get-Item $exeFile).Length
        $exeSizeMB = [Math]::Round($exeSizeBytes / 1MB, 2)
        Write-Host "$($project).exe: $exeSizeMB MB"
    } else {
        Write-Host "$($project).exe not found."
    }

    if (Test-Path $pdbFile) {
        $pdbSizeBytes = (Get-Item $pdbFile).Length
        $pdbSizeMB = [Math]::Round($pdbSizeBytes / 1MB, 2)
        Write-Host "$($project).pdb: $pdbSizeMB MB"
    } else {
        Write-Host "$($project).pdb not found."
    }
}

Pause
