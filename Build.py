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

def print_help():
    parser.print_help()
    sys.exit()

def unity_build(opts):
    logfile = opts['destination'] + "/" + str(uuid.uuid4()) + ".txt"
    command = opts['unity'] +" -quit -batchmode -logFile "+ logfile +" -projectPath "+ opts['project'] +" -executeMethod Build.build"
    
    p = subprocess.run(command.split(), shell=False, check=True, capture_output=True)
    
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
        
    unity_build(optionsdict)