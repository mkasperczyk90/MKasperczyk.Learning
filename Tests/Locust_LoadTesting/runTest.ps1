$path = "results"
If(!(test-path -PathType container $path))
{
      New-Item -ItemType Directory -Path $path
}

$type_of_tests = Read-Host "Which tests you want to run? (load, stress, spike, soak)";

if($type_of_tests -eq "load") {
    locust -f locustfiles/locustfileLoadTests.py --csv=results/loadTests --headless 
} elseif ($type_of_tests -eq "soak") {
    locust -f locustfiles/locustfileSoakTests.py --csv=results/soakTests --headless  
} elseif ($type_of_tests -eq "stress") {
    locust -f locustfiles/locustfileStressTests.py --csv=results/stressTests --headless 
} elseif($type_of_tests -eq "spike") {
    locust -f locustfiles/locustfileSpikeTests.py --csv=results/spikeTests --headless  
} 