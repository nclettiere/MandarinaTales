from optparse import OptionParser
import shlex, subprocess
import os
import sys
import uuid
from threading import Thread, Lock
import tail, time

parser = OptionParser()
parser.add_option("-u", "--unity", dest="unity",
                  help="Path del ejecutable de UNITY", metavar="UNITY")
parser.add_option("-p", "--project", dest="project",
                  help="Path del proyecto de unity", metavar="PROJECT")
parser.add_option("-d", "--destination", dest="destination",
                  help="Path donde se creara el ejecutable", metavar="DESTINATION")
parser.add_option("-m", "--mode", dest="mode",
                  help="Mode en el que se ejecutaran los tests (playmode o editmode)", metavar="MODE")
parser.add_option("-t", "--tests", dest="tests", default=""
                  help="Array separado por commas con los test a ejecutar, si esta vacio se ejecutan todos los tests.", metavar="TESTS")

def print_help():
    parser.print_help()
    sys.exit()

def unity_test(opts):
    logfile = opts['destination'] + "/log.txt"
    
    tests = opts['tests'].split()
    test_results = []
    i = 1
    
    if len(tests) >= 1:
        for test in tests:
            test_result = opts['destination'] + "/" + "test_results.xml"
            command = opts['unity'] +" -quit -batchmode -runTests -testResults "+ test_result +" -logFile "+ logfile +" -projectPath "+ opts['project'] +" -testPlatform "+ opts['mode'] +" -editorTestsFilter " + test
            print(command)
            subprocess.run(command.split(), shell=False, check=True, capture_output=True)
            test_results.append(test_result)
            i += 1
    else:
        test_result = opts['destination'] + "/" + "test_results.xml"
        command = opts['unity'] +" -quit -batchmode -runTests -testResults "+ test_result +" -logFile "+ logfile +" -projectPath "+ opts['project'] +" -testPlatform " + opts['mode']
        subprocess.run(command.split(), shell=False, check=True, capture_output=True)
        test_results.append(test_result)
        i += 1
    
    time.sleep(5)
    
    print("=" * 10)
    with open(logfile, "r") as file:
        for line in file:
            print(line)
    
if __name__ == "__main__":
    (options, args) = parser.parse_args()
    defaults = vars(parser.get_default_values())
    optionsdict = vars(options)
   
    if not optionsdict['unity']:
        print('No se ha ingresado el ejecutable de Unity a usar\n')
        print_help()
    if not optionsdict['project']:
        print('No se ha ingresado el proyecto de unity para buildear\n')
        print_help()
    if not optionsdict['destination']:
        print('No se ha ingresado el directorio de output\n')
        print_help()
        
    unity_test(optionsdict)