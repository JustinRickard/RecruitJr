using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Helpers;

namespace RecruitJr.DB.Seed.Common
{
    public class SeederBase
    {
        protected internal SeederDependencies dependencies;

        protected internal string fileName;

        public SeederBase(
            SeederDependencies dependencies
        ) {
            this.dependencies = dependencies;
        }

        protected internal string SeedFileDirectory 
        {
            get 
            {
                // var directory = Directory.GetCurrentDirectory() + '/' + appSettings.DbSeedingFilesDirectory;
                var directory = dependencies.appSettings.DbSeedingFilesDirectory;
                if (!Directory.Exists(directory)) {
                    throw new Exception("Seed file directory not found: " + directory);
                }

                return directory;
            }
        }       

        protected internal T DeserializeFile<T>() {
            var itemsResult = dependencies.jsonHelper.Deserialize<T>(GetFileContent());
            if (itemsResult.IsFailure) {
                throw new Exception("Could not deserialize file: " + fileName);
            }

            return itemsResult.Value;
        }

        private string GetFileContent() 
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), SeedFileDirectory, fileName);
            return dependencies.fileReader.Read(filePath);
        }

    }
}