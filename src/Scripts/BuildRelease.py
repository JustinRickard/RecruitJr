#!/usr/bin/python3
#
# Builds the outputs for a release version
#

import argparse
import os
import shutil
import tarfile

parser = argparse.ArgumentParser()
parser.add_argument("-v", "--version", help = "Version of the release. e.g. 1.0.0")
parser.add_argument("-o", "--out", help = "Output directory of release files")
parser.add_argument("-s","--src", help = "The project source directory")

args = parser.parse_args()
version = args.version
outputDirectory = args.out
srcDirectory = args.src

if not version:
    print("Please specify a version for the release.")
    quit()

if not outputDirectory:
    outputDirectory = "../../dist/"

if not srcDirectory:
    srcDirectory = "../"

print("Building release version " + version)

versionOutputFolder = outputDirectory + version + "/"

dotnetProjectsToPublish = ['RecruitJr.Api','RecruitJr.DB.Seed.MongoDB']
frontEndProjectsToPublish = ['Frontend.React']


for project in dotnetProjectsToPublish:
    projectOutputFolder = versionOutputFolder + project
    command = "dotnet publish " + srcDirectory + project + " -o " + projectOutputFolder + "/" + " -c Release "
    print("Running command: " + command)
    os.system(command)
    filename =  project + ".tar.gz"
    tar = tarfile.open(filename, "w:gz")
    tar.add(projectOutputFolder, arcname=project)    
    tar.close()
    os.rename("./" + filename, versionOutputFolder + filename)    
    shutil.rmtree(projectOutputFolder)



print("Finished. Packages outputted to " + versionOutputFolder)