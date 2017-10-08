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
        protected internal ILogger<Seeder> logger;
        protected internal AppSettings appSettings;
        protected internal IFileReader fileReader;
        protected internal IJsonHelper jsonHelper;
        protected internal string fileName;

        public SeederBase(
            IOptions<AppSettings> appSettings,
            IFileReader fileReader,
            IJsonHelper jsonHelper,
            ILoggerFactory loggerFactory
            ) {
            this.logger = loggerFactory.CreateLogger<Seeder>();
            this.appSettings = appSettings.Value;
            this.fileReader = fileReader;
            this.jsonHelper = jsonHelper;
        }

        protected internal string SeedFileDirectory 
        {
            get 
            {
                // var directory = Directory.GetCurrentDirectory() + '/' + appSettings.DbSeedingFilesDirectory;
                var directory = appSettings.DbSeedingFilesDirectory;
                if (!Directory.Exists(directory)) {
                    throw new Exception("Seed file directory not found: " + directory);
                }

                return directory;
            }
        }       

        protected internal T DeserializeFile<T>() {
            var itemsResult = jsonHelper.Deserialize<T>(GetFileContent());
            if (itemsResult.IsFailure) {
                throw new Exception("Could not deserialize file: " + fileName);
            }

            return itemsResult.Value;
        }

        private string GetFileContent() 
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), SeedFileDirectory, fileName);
            return fileReader.Read(filePath);
        }

    }
}