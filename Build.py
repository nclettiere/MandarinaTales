from optparse import OptionParser
import subprocess
import os
import sys

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

def unity_build():
    (options, args) = parser.parse_args()
    defaults = vars(parser.get_default_values())
    optionsdict = vars(options)
   
    if 'unity' not in optionsdict:
        print('No se ha ingresado el ejecutable de Unity a usar\n')
        print_help()
    if 'project' not in optionsdict:
        print('No se ha ingresado el projecto de unity para buildear\n')
        print_help()
    if 'destination' not in optionsdict:
        print('No se ha ingresado el directorio de output\n')
        print_help()
        
if __name__ == "__main__":
    unity_build()