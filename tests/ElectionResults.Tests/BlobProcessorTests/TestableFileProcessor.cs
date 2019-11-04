﻿using System.IO;
using System.Threading.Tasks;
using ElectionResults.Core.Services;
using ElectionResults.Core.Services.BlobContainer;
using ElectionResults.Core.Services.CsvProcessing;
using ElectionResults.Core.Storage;
using Microsoft.Extensions.Options;

namespace ElectionResults.Tests.BlobProcessorTests
{
    public class TestableFileProcessor: FileProcessor
    {
        public TestableFileProcessor(IResultsRepository resultsRepository,
            IElectionPresenceAggregator electionPresenceAggregator,
            IStatisticsAggregator statisticsAggregator,
            IOptions<AppConfig> config) : base(resultsRepository, electionPresenceAggregator, statisticsAggregator, config)
        {
        }

        protected override Task<string> ReadCsvContent(Stream csvStream)
        {
            CsvWasReadAsString = true;
            return Task.FromResult("");
        }

        public bool CsvWasReadAsString { get; set; }
    }
}